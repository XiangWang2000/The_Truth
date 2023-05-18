using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondGalleryEnd : MonoBehaviour
{   
    public AudioSource audio;
    private bool toEnd;
    // Start is called before the first frame update
    void Start()
    {
        toEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(toEnd){
            audio.Play(0);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && GameDataManager.state==4)
        {
            toEnd=true;
            Debug.Log("碰到盡頭");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        toEnd=false;
        Debug.Log("離開盡頭");
    }
}
