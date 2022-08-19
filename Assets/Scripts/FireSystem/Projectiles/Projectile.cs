using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public GameObject HitParticle;
    public float Speed = 1;
    private Rigidbody _rb;
    private Collider[] _hit = new Collider[1];
    
    public void ShootProjectile()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = transform.forward * Speed;
    }

    private void Update()
    {
        transform.forward = _rb.velocity.normalized;
        if (Physics.OverlapSphereNonAlloc(transform.position, .25f, _hit) > 0)
        {
            Instantiate(HitParticle, _hit[0].ClosestPoint(transform.position), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
