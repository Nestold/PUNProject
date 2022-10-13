using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRoomsPanel : MonoBehaviour
{
    [SerializeField] private Button createRoomButton = null;
    [SerializeField] private Button joinRoomButton = null;
    [SerializeField] private Button roomsListButton = null;
    [SerializeField] private Button backButton = null;

    private void Start()
    {
        var uiMan = GameManager.Instance.UIManager;
        createRoomButton.onClick.AddListener(() => uiMan.ShowPanel(EUIPanels.CreateRoom));
        joinRoomButton.onClick.AddListener(() => uiMan.ShowPanel(EUIPanels.JoinRoom));
        roomsListButton.onClick.AddListener(() => uiMan.ShowPanel(EUIPanels.RoomsList));
        backButton.onClick.AddListener(() => uiMan.ShowPanel(EUIPanels.MainMenu));
    }
}