using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoviment : MonoBehaviour
{
    private Rigidbody _rb;
    private PlayerInput _input;
    private int speed = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _input = GetComponent<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = new Vector3(_input.MovementAxis().x * speed, _rb.velocity.y, _input.MovementAxis().y * speed);

        float targetAngle = Mathf.Atan2(_input.MovementAxis().x, _input.MovementAxis().y) *  Mathf.Rad2Deg;
        _rb.rotation = Quaternion.Euler(0f, targetAngle, 0f);
    }
}
