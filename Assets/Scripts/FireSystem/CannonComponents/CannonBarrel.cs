using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class CannonBarrel : MonoBehaviour {
    public Projectile Projectile;
    public Transform ExitTransform;

    public void Shoot(float force)
    {
        var proj = Instantiate(Projectile, ExitTransform.position, Quaternion.identity);
        proj.transform.forward = transform.forward;
        proj.Speed *= force;
        proj.ShootProjectile();
    }
}
