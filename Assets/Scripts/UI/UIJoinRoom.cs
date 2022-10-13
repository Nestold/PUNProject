using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIJoinRoom : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_InputField input = null;
    [SerializeField] private Button connectButton = null;
    [SerializeField] private Button backButton = null;

    private void Start()
    {
        backButton.onClick.AddListener(JoinRoom);
        connectButton.onClick.AddListener(() => PhotonNetwork.JoinRoom($"#{input.text}"));
    }

    public void JoinRoom()
    {
        GameManager.Instance.UIManager.ShowPanel(EUIPanels.Room);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log($"Create room failed. Message: {message}");
    }
}
