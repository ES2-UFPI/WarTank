using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCannon : MonoBehaviour {
    public CannonTrigger Trigger;
    public CannonBarrel Barrel;
    public PlayerInput PlayerInput;


    private void Update()
    {
        if (Trigger.WantToShoot(PlayerInput))
        {
            Barrel.Shoot(PlayerInput.FireForce());
        }
    }
}
