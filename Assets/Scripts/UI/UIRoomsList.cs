using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class UIRoomsList : MonoBehaviourPunCallbacks
{
    [SerializeField] private UIServerListElement roomListElement = null;
    [SerializeField] private Transform content = null;
    [SerializeField] private Button refreshButton = null;
    [SerializeField] private Button backButton = null;

    private List<RoomInfo> roomList = new List<RoomInfo>();
    private float refreshTimer = 0;

    private void Start()
    {
        backButton.onClick.AddListener(() => GameManager.Instance.UIManager.ShowPanel(EUIPanels.Play));
        refreshButton.onClick.AddListener(ForceUpdateRoomList);
    }
    private void Update()
    {
        if(refreshTimer > 5)
        {
            UpdateRoomList();
            refreshTimer = 0;
        }
        else
        {
            refreshTimer += Time.deltaTime;
        }
    }
    public override void OnEnable()
    {
        base.OnEnable(); 
        ForceUpdateRoomList();
    }

    public void ForceUpdateRoomList()
    {
        UpdateRoomList();
        refreshTimer = 0;
    }

    private void ClearAllRooms()
    {
        foreach(Transform t in content)
        {
            Destroy(t.gameObject);
        }
    }
    private void UpdateRoomList()
    {
        ClearAllRooms();
        foreach (var r in roomList)
        {
            if (!r.RemovedFromList)
            {
                var roomUI = Instantiate(roomListElement, content);
                roomUI.Setup(r.Name, r.PlayerCount, r.MaxPlayers);
            }
        }
    }

    public override void OnJoinedRoom()
    {
        GameManager.Instance.UIManager.ShowPanel(EUIPanels.Room);
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        this.roomList = roomList;
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log($"Create room failed. Message: {message}");
    }
}