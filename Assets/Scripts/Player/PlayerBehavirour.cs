using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class PlayerBehavirour : NetworkBehaviour, IDamagable {
    [Networked]
    private float _health { get; set; } = 100f;

    public override void Spawned()
    {
        if (Object.HasInputAuthority)
        {
            FindObjectOfType<CameraFollow>().SetTarget(transform);
            GameManager.Instance.RPC_SetPlayerNick(Object.InputAuthority, StaticData.PlayerNick);
        }
    }

    public void ReceiveDamage(float amount)
    {
        if (!Object || !Object.HasStateAuthority) return;
        _health -= amount;
        if (_health <= 0)
            Explode();
    }

    private void Explode()
    {
        if (Object.HasStateAuthority)
        {
            Runner.Despawn(Object);
        }
    }

    private void OnDestroy()
    {
        FindObjectOfType<LevelManager>().CheckWinner();
    }
}
