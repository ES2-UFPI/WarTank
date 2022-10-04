using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using UnityEngine;

public class GameManager : NetworkBehaviour {
    public static GameManager Instance;
    
    public static NetworkCallbacks Callbacks = new NetworkCallbacks();
    [Networked, Capacity(4)] public NetworkDictionary<int, NetworkString<_16>> Nicks => default;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public override void Spawned()
    {
        Instance = this;
    }
    
    [Rpc(RpcSources.All, RpcTargets.StateAuthority)]
    public void RPC_SetPlayerNick(PlayerRef player, string nick)
    {
        Nicks.Add(player, nick);
    }

    public string GetPlayerNick(PlayerRef player)
    {
        return Nicks[player].Value;
    }
}
