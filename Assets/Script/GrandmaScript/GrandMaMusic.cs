using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandMaMusic : MonoBehaviour
{   
    public AudioSource GrandMaRoom;
    public AudioSource GrandMa ;
    // Start is called before the first frame update
    void Start(){
        Debug.Log("現在的階段是:"+GameDataManager.state);
        if(GameDataManager.state == 3){
            Debug.Log("現在的音效是:鬼場景");
            GrandMa.Play(0);
        }else{
            Debug.Log("現在的音效是:二樓");
            GrandMaRoom.Play(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

