using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIConnection : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI connectionStatus = null;
    [SerializeField] private TextMeshProUGUI nickname = null;

    public void SetConnectionStatus(bool connected)
    {
        connectionStatus.text = connected ? "Connected" : "Disconnected";
        connectionStatus.color = connectionStatus ? Color.green : Color.red;
    }
    public void SetNickname(string nickname)
    {
        this.nickname.text = nickname;
    }
}
