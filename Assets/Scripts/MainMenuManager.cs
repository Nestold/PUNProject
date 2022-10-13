using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [Header("Buttos")]
    [SerializeField] private Button playButton = null;
    [SerializeField] private Button settingsButton = null;
    [SerializeField] private Button quitButton = null;

    private void Start()
    {
        playButton.onClick.AddListener(() => GameManager.Instance.UIManager.ShowPanel(EUIPanels.Play));
        quitButton.onClick.AddListener(() => Application.Quit());
    }
}