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

    public bool CanShoot(NetworkInput input) {
        return Trigger.CantToShoot(input, _prevInput.Buttons) && Object.HasStateAuthority;
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput<NetworkInput>(out var input))
        {
            if (this.CanShoot(input))
            {
                Barrel.Shoot(input.FireForce, Runner);
                SoundManager.Instance.PlaySound(FireSound);
            }
            
            _prevInput = input;
        }
    }
}
