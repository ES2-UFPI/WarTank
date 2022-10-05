using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [HideInInspector]
    public Transform Target;
    public float Speed;

    private void LateUpdate()
    {
        if (Target)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
        }
    }

    public void SetTarget(Transform t)
    {
        Target = t;
    }
}
