using System;
using System.Collections.Generic;
using Fusion;
using Fusion.Sockets;
using UnityEngine;

public class PlayerInput : InputProvider, INetworkRunnerCallbacks {
    public override bool IsFireHold() => Input.GetButton("Fire1");
    public override bool IsFirePressed() => Input.GetButtonDown("Fire1");
    public override bool IsFireReleased() => Input.GetButtonUp("Fire1");
    public override Vector2 MovementAxis() => new(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    public override float FireForce() => _force;

    private float _force = 1;
    private float _maxForce = 3;

    private void Awake()
    {
        FindObjectOfType<NetworkRunner>().AddCallbacks(this);
    }

    private void Update()
    {
        if (IsFirePressed()) _force = 1;
        
        if (IsFireHold() && _force < _maxForce)
        {
            _force += Time.deltaTime;
        }
    }
    
    public void OnInput(NetworkRunner runner, Fusion.NetworkInput input)
    {
        var myInput = new NetworkInput();
        myInput.Dir = MovementAxis();
        myInput.Buttons.Set(Buttons.Fire, IsFireHold());
        myInput.FireForce = FireForce();
        input.Set(myInput);
    }

    // Unused Callbacks
    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player) {}
    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player) {}
    public void OnInputMissing(NetworkRunner runner, PlayerRef player, Fusion.NetworkInput input) {}
    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason) {}
    public void OnConnectedToServer(NetworkRunner runner) {}
    public void OnDisconnectedFromServer(NetworkRunner runner) {}
    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token) {}
    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason) {}
    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message) {}
    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList) {}
    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data) {}
    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken) {}
    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data) {}
    public void OnSceneLoadDone(NetworkRunner runner) {}
    public void OnSceneLoadStart(NetworkRunner runner) {}
}
