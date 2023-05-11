using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMomCry : MonoBehaviour
{   
    public AudioSource MomCry;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
           MomCry.Play(0);
           Debug.Log("播媽媽哭泣音效");
        }


    }
}
