using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIRoomCode : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI codeDisplay = null;
    [SerializeField] private Button hideButton = null;

    private string code = "";
    private bool isHided = false;

    private void Start()
    {
        hideButton.onClick.AddListener(OnHideButtonClick);
    }

    public void OnHideButtonClick()
    {
        isHided = !isHided;
        if(isHided)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }
    public void SetCode(string code)
    {
        this.code = code;
        Hide();
    }

    public void Show()
    {
        codeDisplay.text = code;
        isHided = false;
    }
    public void Hide()
    {
        codeDisplay.text = "****";
        isHided = true;
    }
}
