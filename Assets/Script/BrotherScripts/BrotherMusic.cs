using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrotherMusic : MonoBehaviour
{   
    public AudioSource BrotherRoom;
    public AudioSource Brother ;
    // Start is called before the first frame update
    void Start()
    {   
        Debug.Log("現在的階段是:"+GameDataManager.state);
        if(GameDataManager.state == 2){
            Debug.Log("現在的音效是:鬼場景");
            Brother.Play(0);
        }else{
            Debug.Log("現在的音效是:二樓");
            BrotherRoom.Play(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
