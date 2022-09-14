using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class PlayerBehavirour : NetworkBehaviour, IDamagable {
    [Networked]
    private float _health { get; set; } = 100f;


    public void ReceiveDamage(float amount)
    {
        _health -= amount;
        if (_health <= 0)
            Explode();
    }

    private void Explode()
    {
        Runner.Despawn(Object);
    }
}
