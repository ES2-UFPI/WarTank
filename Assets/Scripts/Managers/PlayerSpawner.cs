using System;
using System.Collections.Generic;
using Fusion;
using Fusion.Sockets;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerSpawner : NetworkBehaviour, INetworkRunnerCallbacks {
    public NetworkPrefabRef PlayerTank;

    public override void Spawned()
    {
        Runner.AddCallbacks(this);
    }
    
    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        var pos = Random.insideUnitSphere * 2;
        pos.y = 1;
        if (Object.HasStateAuthority)
        {
            Runner.Spawn(PlayerTank, pos, inputAuthority: player);
        }
        
        
    }
    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
    }
    public void OnInput(NetworkRunner runner, Fusion.NetworkInput input)
    {
    }
    public void OnInputMissing(NetworkRunner runner, PlayerRef player, Fusion.NetworkInput input)
    {
    }
    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
    }
    public void OnConnectedToServer(NetworkRunner runner)
    {
    }
    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
    }
    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
    }
    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
    }
    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
    }
    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
    }
    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
    }
    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
    }
    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
    }
    public void OnSceneLoadDone(NetworkRunner runner)
    {
    }
    public void OnSceneLoadStart(NetworkRunner runner)
    {
    }
}
