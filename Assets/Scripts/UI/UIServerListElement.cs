using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Photon.Pun;

public class UIServerListElement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hostName = null;
    [SerializeField] private TextMeshProUGUI currentPlayers = null;
    [SerializeField] private TextMeshProUGUI maxPlayers = null;
    [SerializeField] private Button connectButton = null;

    private string roomCode = "";

    public void Setup(string roomCode, int players, byte maxPlayers)
    {
        this.roomCode = roomCode;
        currentPlayers.text = players.ToString("00");
        this.maxPlayers.text = maxPlayers.ToString("00");
        connectButton.onClick.AddListener(() => PhotonNetwork.JoinRoom(this.roomCode));
    }
}