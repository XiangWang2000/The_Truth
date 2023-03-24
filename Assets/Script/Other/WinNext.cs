using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinNext : MonoBehaviour
{   

    // Start is called before the first frame update
    void Start()
    {
        GameDataManager.state = 2;
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Space)){
            SceneManager.LoadScene("SecondScene");
        }
    }
}
