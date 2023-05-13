using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaMove : MonoBehaviour
{
    private GameObject Player;
    private bool isStartMove;
    public float Speed=1;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {   
        sr = GetComponent<SpriteRenderer>();
        Player = GameObject.FindGameObjectWithTag("Player");
        isStartMove = false;
    }
    void Update()
    {   
        if(this.gameObject.transform.position.x<Player.transform.position.x){
            sr.flipX = true;
        }else{
            sr.flipX = false;
        }
        //Debug.Log(this.gameObject.transform.position.x-Player.transform.position.x);
        if((this.gameObject.transform.position.x-Player.transform.position.x)<15.0f){
            isStartMove = true;
            Debug.Log("奶奶攻擊!");
        }
        if(isStartMove){
            Debug.Log("奶奶開跑!");
            this.gameObject.transform.position = Vector3.MoveTowards
            (this.gameObject.transform.position,Player.transform.position, Speed*Time.deltaTime);
        }
    }
    
}
