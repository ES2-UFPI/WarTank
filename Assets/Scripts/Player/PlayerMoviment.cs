using Fusion;
using System.Diagnostics;
using UnityEngine;

[DebuggerDisplay("{" + nameof(GetDebuggerDisplay) + "(),nq}")]
public class PlayerMoviment : NetworkBehaviour
{
    private NetworkRigidbody _rb;

    [Networked]
    private int _speed { get; set; } = 50;
    [Networked]
    private int _turnSpeed { get; set; } = 90;
    [Networked]
    private float _maxSpeed { get; set; } = 15;

    private AudioSource _source;

    public override void Spawned()
    {
        _rb = GetComponent<NetworkRigidbody>();
        _source = GetComponent<AudioSource>();
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

        if (_rb.Rigidbody.velocity != Vector3.zero && !_source.isPlaying)
        {

            _source.Play();

        }
        else if (_source.isPlaying)
        {

            _source.Stop();

        }

        if (_rb.Rigidbody.velocity.magnitude > _maxSpeed)
        {
            _rb.Rigidbody.velocity = Vector3.ClampMagnitude(_rb.Rigidbody.velocity, _maxSpeed);
        }
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
