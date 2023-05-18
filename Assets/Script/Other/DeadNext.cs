using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadNext : MonoBehaviour
{   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {      
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log(GameDataManager.state);
        }
        if(Input.GetKeyDown(KeyCode.Space)&&GameDataManager.state==1){
            SceneManager.LoadScene("FirstScene");
        }
        else if(Input.GetKeyDown(KeyCode.Space)&&GameDataManager.state==2){
            SceneManager.LoadScene("SecondScene");
        }
        else if(Input.GetKeyDown(KeyCode.Space)&&GameDataManager.state==3){
            SceneManager.LoadScene("SecondScene");
        }
    }
}
