using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    #region Singleton
    public static GameManager Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Debug.LogError("[Singleton Duplication] This object cannot be exist twice !");
            Destroy(gameObject);
        }
    }
    #endregion

    [Header("Dependecies")]
    //public NetworkManager NetworkManager;
    public UIManager UIManager;

    [Header("Nestwork Settings")]
    public GameSettings GameSettings;

    private void Start()
    {
        ConnectToServer(GameSettings);
    }


    public void ConnectToServer(GameSettings gameSettings)
    {
        Debug.Log($"Connecting to server.");
        PhotonNetwork.NickName = gameSettings.Nickname;
        PhotonNetwork.GameVersion = gameSettings.GameVersion;
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        var uCon = UIManager.UIConnection;
        uCon.SetConnectionStatus(true);
        uCon.SetNickname(PhotonNetwork.LocalPlayer.NickName);

        PhotonNetwork.JoinLobby();
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        var uCon = UIManager.UIConnection;
        uCon.SetConnectionStatus(false);
        uCon.SetNickname("###");
        Debug.Log($"Disconnected from server [{cause}]");
    }
}