using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] private UIPlayerListElement playerListElement = null;
    [SerializeField] private Button leaveButton = null;
    [SerializeField] private UIRoomCode roomCodeDisplay = null;

    [Header("Control buttons")]
    [SerializeField] private Button readyButton = null;
    [SerializeField] private Button unreadyButton = null;
    [SerializeField] private Button startButton = null;

    private void Start()
    {
        leaveButton.onClick.AddListener(() => PhotonNetwork.LeaveRoom());
    }

    private void SetupReadyButtons(bool isMasterClient)
    {
        if (isMasterClient)
        {
            readyButton.gameObject.SetActive(true);
            unreadyButton.gameObject.SetActive(false);
            startButton.gameObject.SetActive(true);
        }
        else
        {
            readyButton.gameObject.SetActive(true);
            unreadyButton.gameObject.SetActive(false);
            startButton.gameObject.SetActive(false);
        }
    }

    public override void OnJoinedRoom()
    {
        Debug.Log($"OnJoinedRoom");
        SetupReadyButtons(PhotonNetwork.IsMasterClient);
        roomCodeDisplay.SetCode(PhotonNetwork.CurrentRoom.Name);
    }
    public override void OnLeftRoom()
    {
        GameManager.Instance.UIManager.ShowPanel(EUIPanels.Play);
    }
}