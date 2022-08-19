using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    private Rigidbody _rb;
    private PlayerInput _input;
    private int _speed = 15;
    private int _turnSpeed = 50;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, _input.MovementAxis().x  * _turnSpeed * Time.deltaTime);

        if (_input.MovementAxis().y != 0)
        {
            Debug.Log(_input.MovementAxis().y);
            _rb.velocity = transform.forward * _input.MovementAxis().y * _speed;
        }
    }
}
