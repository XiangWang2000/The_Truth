using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletMusic : MonoBehaviour
{   
    public AudioSource Toilet;
    public AudioSource Dad ;
    // Start is called before the first frame update
    void Start()
    {
        if(GameDataManager.state == 1){
            Dad.Play(0);
        }else{
            Toilet.Play(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
