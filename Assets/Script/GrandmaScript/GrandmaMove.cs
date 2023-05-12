using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaMove : MonoBehaviour
{
    private GameObject Player;
    private bool isStartMove;
    public float Speed=5;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        isStartMove = false;
    }
    void Update()
    {   
        Debug.Log(this.gameObject.transform.position.x-Player.transform.position.x);
        if(this.gameObject.transform.position.x-Player.transform.position.x<15){
            isStartMove = true;
            Debug.Log("奶奶攻擊!");
        }
        if(isStartMove){
            this.gameObject.transform.position = Vector3.MoveTowards
            (this.gameObject.transform.position,Player.transform.position, Speed*Time.deltaTime);
        }
    }
    
}
