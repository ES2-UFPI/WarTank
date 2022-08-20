using System;
using UnityEngine;
public class PlayerInput : InputProvider {
    public override bool IsFireHold() => Input.GetButton("Fire1");
    public override bool IsFirePressed() => Input.GetButtonDown("Fire1");
    public override bool IsFireReleased() => Input.GetButtonUp("Fire1");
    public override Vector2 MovementAxis() => new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    public override float FireForce() => _force;

    private float _force = 1;
    private float _maxForce = 3;

    private void Update()
    {
        if (IsFirePressed()) _force = 1;
        
        if (IsFireHold() && _force < _maxForce)
        {
            _force += Time.deltaTime;
        }
    }
}
