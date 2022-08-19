using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTrigger : MonoBehaviour {
    public float ShootCD = 1f;
    
    private float _lastShootTime;
    
    public bool WantToShoot(PlayerInput input)
    {
        if (input.IsFireReleased())
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
