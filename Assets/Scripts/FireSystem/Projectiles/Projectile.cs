using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public float Speed = 1;
    private Rigidbody _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = transform.forward * Speed;
        Invoke(nameof(DestroyAfterTimePlaceHolder), 3f);
    }

    private void DestroyAfterTimePlaceHolder()
    {
        Destroy(gameObject);
    }
}
