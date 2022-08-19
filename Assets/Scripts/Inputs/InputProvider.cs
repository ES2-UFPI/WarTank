using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputProvider : MonoBehaviour {

    public abstract bool IsFirePressed();
    public abstract Vector2 MovementAxis();
    public abstract Vector3 AimPos();
}
