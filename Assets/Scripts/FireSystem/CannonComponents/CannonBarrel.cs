using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class CannonBarrel : MonoBehaviour {
    public GameObject Projectile;
    public Transform ExitTransform;

    public void Shoot()
    {
        Instantiate(Projectile, ExitTransform.position, Quaternion.identity).transform.forward = transform.forward;
    }
}
