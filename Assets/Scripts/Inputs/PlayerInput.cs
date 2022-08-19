using System;
using UnityEngine;
public class PlayerInput : InputProvider {
    private Ray _mouseRay;
    private Camera _mainCamera;

    public override bool IsFirePressed() => Input.GetButtonDown("Fire1");
    public override Vector2 MovementAxis() => new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

    private void Start()
    {
        _mainCamera = Camera.main;
    }
    public override Vector3 AimPos()
    {
        _mouseRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(_mouseRay, out RaycastHit hit))
        {
            return hit.point;
        }
        return transform.position + transform.forward * 5;
    }
}
