using System;
using System.Collections;
using System.Collections.Generic;
using Fusion;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour {
    public Launcher Launcher;
    public TMP_InputField RoomInput;
    public TMP_InputField NickInput;
    public GameObject StartButton;

    private void OnEnable()
    {
        GameManager.Callbacks.Event_OnShutdown += ConnectionFailed;
    }

    private void OnDisable()
    {
        GameManager.Callbacks.Event_OnShutdown -= ConnectionFailed;
    }

    public void StartLauncher()
    {
        StaticData.PlayerNick = NickInput.text;
        Launcher.Launch(RoomInput.text);
    }

    private void ConnectionFailed(NetworkRunner runner)
    {
        StartButton.SetActive(true);
    }
}
