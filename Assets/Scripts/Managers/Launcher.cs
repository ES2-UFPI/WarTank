using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class Launcher : MonoBehaviour {
    public NetworkRunner Runner;
    public NetworkPrefabRef GameManagerPrefabRef;

    public void Launch(string session)
    {
        Runner = Instantiate(Runner);
        Runner.AddCallbacks(GameManager.Callbacks);
        Runner.ProvideInput = true;
        var pool = Runner.GetComponent<NetworkObjectPoolDefault>();
        Runner.StartGame(new StartGameArgs()
        { SessionName = session,
          GameMode = GameMode.AutoHostOrClient,
          ObjectPool = pool,
          Scene = 1, Initialized = (runner => runner.Spawn(GameManagerPrefabRef)) });
    }
}
