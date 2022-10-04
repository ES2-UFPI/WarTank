using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class TankCannon : NetworkBehaviour {
    public CannonTrigger Trigger;
    public CannonBarrel Barrel;
    private NetworkInput _prevInput;
    public AudioClip FireSound;

    public override void FixedUpdateNetwork()
    {
        if (GetInput<NetworkInput>(out var input))
        {
            if (Trigger.CantToShoot(input, _prevInput.Buttons) && Object.HasStateAuthority)
            {
                Barrel.Shoot(input.FireForce, Runner);
                SoundManager.Instance.PlaySound(FireSound);
            }
            
            _prevInput = input;
        }
    }
}
