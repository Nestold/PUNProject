using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Manager/GameSettings")]
public class GameSettings : ScriptableObject
{
    public string Nickname
    {
        get
        {
            return nickname + "#" +
                UnityEngine.Random.Range(0, 9) + UnityEngine.Random.Range(0, 9) +
                UnityEngine.Random.Range(0, 9) + UnityEngine.Random.Range(0, 9);
        }
    }
    public string GameVersion = "0.0.0";

    [SerializeField] private string nickname = "";
}