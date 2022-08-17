using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCannon : MonoBehaviour {
    public CannonTrigger Trigger;
    public CannonBarrel Barrel;

    private void Update()
    {
        if (Trigger.WantToShoot())
        {
            Barrel.Shoot();
        }
    }
}
