using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    private Rigidbody _rb;
    private PlayerInput _input;
    private int _speed = 50;
    private int _turnSpeed = 90;
    private float _maxSpeed = 15;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.MovementAxis().x != 0)
        {
            transform.Rotate(Vector3.up, this.CalcRotate(_input.MovementAxis().x , _turnSpeed , Time.deltaTime));
        }

        if (_input.MovementAxis().y != 0)
        {
            _rb.AddForce(transform.forward * this.CalcMovementForce( _input.MovementAxis().y , _speed , Time.deltaTime), ForceMode.Impulse);
        }

        if (_rb.velocity.magnitude > _maxSpeed)
        {
            _rb.velocity = Vector3.ClampMagnitude(_rb.velocity, _maxSpeed);
        }
    }

    public float CalcRotate(float MovementAxisX, float TurnSpeed, float DeltaTime)
    {
        return MovementAxisX * TurnSpeed * DeltaTime;
    }

    public float CalcMovementForce(float MovementAxisY, float Speed, float DeltaTime)
    {
        return MovementAxisY * Speed * DeltaTime;
    }
}
