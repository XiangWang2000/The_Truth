using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandMaMoveOut : MonoBehaviour
{
    private GameObject Player;
    public float Speed=2;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {   
        sr = GetComponent<SpriteRenderer>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {   
        if(this.gameObject.transform.position.x<Player.transform.position.x){
            sr.flipX = true;
        }else{
            sr.flipX = false;
        }
        Debug.Log("奶奶開跑!");
        this.gameObject.transform.position = Vector3.MoveTowards
            (this.gameObject.transform.position,Player.transform.position, Speed*Time.deltaTime);
        
    }
    
}
