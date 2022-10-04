using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Fusion;
using UnityEngine;

public class NetworkObjectPoolDefault : MonoBehaviour, INetworkObjectPool {
    
    [Tooltip("The objects to be pooled, leave it empty to pool every Network Object spawned")]
    [SerializeField] private List<NetworkPrefabRef> _poolableObjects = new List<NetworkPrefabRef>();
    
    private Dictionary<NetworkPrefabId, Stack<NetworkObject>> _free = new Dictionary<NetworkPrefabId, Stack<NetworkObject>>();

    public NetworkObject AcquireInstance(NetworkRunner runner, NetworkPrefabInfo info)
    {
        if (ShouldPool(runner, info))
        {
            var instance = GetObjectFromPool(runner, info);
            
            instance.transform.position = Vector3.zero;

            return instance;
        }

        return InstantiateObject(runner, info);
    }

    public void ReleaseInstance(NetworkRunner runner, NetworkObject instance, bool isSceneObject)
    {
        if (isSceneObject)
        {
            Destroy(instance.gameObject);
            return;
        }
        
        if (runner.Config.PrefabTable.TryGetId(instance.NetworkGuid, out var prefabId))
        {
            if (_free.TryGetValue(prefabId, out var stack))
            {
                if (instance.transform.childCount > 0)
                    DespawnChildren(runner, instance);
                
                instance.gameObject.SetActive(false);
                stack.Push(instance);
            }
            else
            {
                Destroy(instance.gameObject);
            }
            return;
        }
        
        // If no prefabId was found
        Destroy(instance.gameObject);
    }

    private void DespawnChildren(NetworkRunner runner, NetworkObject instance)
    {
        var childNO = instance.GetComponentsInChildren<NetworkObject>();
        foreach (var networkObject in childNO)
        {
            networkObject.Id.Raw = 0;
           // runner.Despawn(networkObject);
        }
    }

    private NetworkObject GetObjectFromPool(NetworkRunner runner, NetworkPrefabInfo info)
    {
        NetworkObject instance = null;

        if (_free.TryGetValue(info.Prefab, out var stack))
        {
            while (stack.Count > 0 && instance == null)
            {
                instance = stack.Pop();
            }
        }

        if (instance == null)
            instance = GetNewInstance(runner, info);
        
        instance.gameObject.SetActive(true);
        return instance;
    }

    private NetworkObject GetNewInstance(NetworkRunner runner, NetworkPrefabInfo info)
    {
        NetworkObject instance = InstantiateObject(runner, info);

        if (_free.TryGetValue(info.Prefab, out var stack) == false)
        {
            stack = new Stack<NetworkObject>();
            _free.Add(info.Prefab, stack);
        }
            
        return instance;
    }

    private NetworkObject InstantiateObject(NetworkRunner runner, NetworkPrefabInfo info)
    {
        if (runner.Config.PrefabTable.TryGetPrefab(info.Prefab, out var prefab))
        {
            return Instantiate(prefab);
        }
        
        Debug.LogError("No prefab for " + info.Prefab);
        return null;
    }

    private bool ShouldPool(NetworkRunner runner, NetworkPrefabInfo info)
    {
        if (runner.Config.PrefabTable.TryGetPrefab(info.Prefab, out var networkObject))
        {
            if (_poolableObjects.Count == 0)
            {
                return true;
            }
            
            if (IsPoolableObject(networkObject))
            {
                return true;
            }
        } else
        {
            Debug.LogError("No prefab found.");
        }
        return false;
    }

    private bool IsPoolableObject(NetworkObject networkObject)
    {
        foreach (var poolableObject in _poolableObjects)
        {
            if ((Guid)poolableObject == (Guid)networkObject.NetworkGuid)
                return true;
        }
        return false;
    }
}
