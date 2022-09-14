using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class TankCannon : NetworkBehaviour {
    public CannonTrigger Trigger;
    public CannonBarrel Barrel;
    private NetworkInput _prevInput;

    public override void FixedUpdateNetwork()
    {
        if (GetInput<NetworkInput>(out var input))
        {
            if (Trigger.CantToShoot(input, _prevInput.Buttons))
            {
                Barrel.Shoot(input.FireForce, Runner);
            }
            
            _prevInput = input;
        }
    }
}
