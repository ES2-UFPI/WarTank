using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class CannonTrigger : MonoBehaviour {
    public float ShootCD = 1f;
    
    private float _lastShootTime;
    
    public bool CantToShoot(NetworkInput input, NetworkButtons previous)
    {
        if (input.Buttons.WasReleased(previous, Buttons.Fire))
        {
            if (Time.time - _lastShootTime >= ShootCD)
            {
                _lastShootTime = Time.time;
                return true;
            }
        }
        return false;
    }
}
