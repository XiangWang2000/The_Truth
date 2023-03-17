using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public void OnStartGame (string ScneneName)
    {
        //載入該名稱場景
        Application.LoadLevel(ScneneName);
    } 
}
