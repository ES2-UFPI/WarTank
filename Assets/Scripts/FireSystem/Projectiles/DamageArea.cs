using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class DamageArea : SimulationBehaviour, ISpawned {
    public float Damage = 0;
    public GameObject HitPaticle;
    
    public void Spawned()
    {
        Instantiate(HitPaticle, transform.position, Quaternion.identity);
        Collider[] col = Physics.OverlapSphere(transform.position, 3, LayerMask.GetMask("Damageable"));
        foreach (var collider1 in col)
        {
            if (!collider1) continue;
            if (collider1.transform.parent.TryGetComponent<IDamagable>(out var damagable))
            {
                damagable.ReceiveDamage(Damage);
            }
        }
        Invoke(nameof(Destroy), 1f);
    }

    private void Destroy()
    {
        Runner.Despawn(Object);
    }
}
