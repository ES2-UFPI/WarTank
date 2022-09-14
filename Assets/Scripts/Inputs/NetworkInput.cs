using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public enum Buttons{Fire}

public struct NetworkInput : INetworkInput {
    public Vector2 Dir;
    public NetworkButtons Buttons;
    public float FireForce;
}
