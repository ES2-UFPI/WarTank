using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using Fusion.Sockets;

public class PlayerMoviment : NetworkBehaviour {
    private NetworkRigidbody _rb;

    [Networked]
    private int _speed { get; set; } = 50;
    [Networked]
    private int _turnSpeed { get; set; } = 90;
    [Networked]
    private float _maxSpeed { get; set; } = 15;

    public override void Spawned()
    {
        _rb = GetComponent<NetworkRigidbody>();
    }

    public override void FixedUpdateNetwork()
    {
        if (!Object.HasStateAuthority) return;

        if (GetInput<NetworkInput>(out var input))
        {
            if (input.Dir.x != 0)
            {
                transform.Rotate(Vector3.up, input.Dir.x * _turnSpeed * Runner.DeltaTime);
            }

            if (input.Dir.y != 0)
            {
                _rb.Rigidbody.AddForce(transform.forward * input.Dir.y * _speed * Runner.DeltaTime, ForceMode.Impulse);
            }
        }

        if (_rb.Rigidbody.velocity.magnitude > _maxSpeed)
        {
            _rb.Rigidbody.velocity = Vector3.ClampMagnitude(_rb.Rigidbody.velocity, _maxSpeed);
        }
    }

    
}
