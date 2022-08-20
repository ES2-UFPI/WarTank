using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputProvider : MonoBehaviour {

    public abstract bool IsFireHold();
    public abstract bool IsFirePressed();
    public abstract bool IsFireReleased();
    public abstract Vector2 MovementAxis();
    public abstract float FireForce();
}
