using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class Launcher : MonoBehaviour {
    public NetworkRunner Runner;

    public void Launch(string session)
    {
        Runner = Instantiate(Runner);
        Runner.AddCallbacks(GameManager.Callbacks);
        Runner.ProvideInput = true;
        Runner.StartGame(new StartGameArgs()
        { SessionName = session,
          GameMode = GameMode.AutoHostOrClient,
          Scene = 1, });
    }
}
