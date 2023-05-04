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
        if(GameDataManager.state == 2){
            Brother.Play(0);
        }else{
            BrotherRoom.Play(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
