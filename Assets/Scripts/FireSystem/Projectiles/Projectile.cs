using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class Projectile : NetworkBehaviour {
    public NetworkPrefabRef HitParticle;
    [Networked]
    public float Speed { get; set; } = 1;
    [Networked]
    public float Damage { get; set; } = 25;
    private NetworkRigidbody _rb;
    private Collider[] _hit = new Collider[1];
    
    public void ShootProjectile()
    {
        _rb = GetComponent<NetworkRigidbody>();
        _rb.Rigidbody.velocity = transform.forward * Speed;
    }

    public override void Spawned()
    {
        _rb = GetComponent<NetworkRigidbody>();
    }

    public override void FixedUpdateNetwork()
    {
        if (!Object.HasStateAuthority) return;
        
        transform.forward = _rb.Rigidbody.velocity.normalized;
        if (Runner.IsForward && Physics.OverlapSphereNonAlloc(transform.position, .25f, _hit) > 0)
        {
            Runner.Spawn(HitParticle, _hit[0].ClosestPoint(transform.position), Quaternion.identity, onBeforeSpawned: (r, n) => n.GetComponent<DamageArea>().Damage = Damage);
            Runner.Despawn(Object);
        }
    }
}
