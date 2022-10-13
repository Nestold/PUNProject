using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using System;

public class UICreateRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] private Toggle privateRoomToggle = null;
    [SerializeField] private Button createRoomButton = null;
    [SerializeField] private Button backButton = null;

    private void Start()
    {
        createRoomButton.onClick.AddListener(OnCreateRoomClick);
        backButton.onClick.AddListener(OnBack);
    }

    private void OnBack()
    {
        GameManager.Instance.UIManager.ShowPanel(EUIPanels.Play);
    }
    private void OnCreateRoomClick()
    {
        if(PhotonNetwork.IsConnected)
        {
            RoomOptions options = new RoomOptions();
            options.MaxPlayers = 10;
            options.IsVisible = !privateRoomToggle.isOn;
            PhotonNetwork.CreateRoom(GenerateRoomID(), options, TypedLobby.Default);
        }
    }
    private string GenerateRoomID()
    {
        return "#" + UnityEngine.Random.Range(0, 9) + 
            UnityEngine.Random.Range(0, 9) + 
            UnityEngine.Random.Range(0, 9) + 
            UnityEngine.Random.Range(0, 9) + 
            UnityEngine.Random.Range(0, 9);
    }

    public override void OnCreatedRoom()
    {
        GameManager.Instance.UIManager.ShowPanel(EUIPanels.Room);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log($"Create room failed. Message: {message}");
    }
}
