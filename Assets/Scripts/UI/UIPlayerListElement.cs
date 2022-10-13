using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPlayerListElement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerName = null;
    [SerializeField] private GameObject readyCheckBox = null;

    public void Setup(string playerName)
    {
        this.playerName.text = playerName;
        SetReady(false);
    }
    public void SetReady(bool ready)
    {
        readyCheckBox.SetActive(ready);
    }
}
