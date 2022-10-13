using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Dependencies")]
    public UIConnection UIConnection = null;
    [Header("Panels")]
    [SerializeField] private List<GameObject> panels = null;

    public void ShowPanel(EUIPanels panel)
    {
        CloseAllPanels();
        panels[(int)panel].SetActive(true);
    }
    private void CloseAllPanels()
    {
        foreach(var p in panels)
        {
            p.SetActive(false);
        }
    }
}

[System.Serializable]
public enum EUIPanels
{
    MainMenu = 0,
    Play = 1,
    CreateRoom = 2,
    JoinRoom = 3,
    RoomsList = 4,
    Room = 5
}