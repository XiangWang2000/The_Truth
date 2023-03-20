using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public float runspeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow) | Input.GetKey("a") & Input.GetKey(KeyCode.LeftShift)|Input.GetKey(KeyCode.RightShift)){
            transform.Translate(-runspeed*Time.deltaTime,0,0);
            if(transform.localScale.x>0){
            transform.localScale=new Vector3(transform.localScale.x*-1,transform.localScale.y,transform.localScale.z);
        }
        }else if(Input.GetKey(KeyCode.RightArrow) | Input.GetKey("d") & Input.GetKey(KeyCode.LeftShift)|Input.GetKey(KeyCode.RightShift)){
            transform.Translate(runspeed*Time.deltaTime,0,0);
            if(transform.localScale.x<0){
            transform.localScale=new Vector3(transform.localScale.x*-1,transform.localScale.y,transform.localScale.z);
        }
        }else if(Input.GetKey(KeyCode.RightArrow) | Input.GetKey("d")){
            transform.Translate(speed*Time.deltaTime,0,0);
            if(transform.localScale.x<0){
            transform.localScale=new Vector3(transform.localScale.x*-1,transform.localScale.y,transform.localScale.z);
        }
        }
        else if(Input.GetKey(KeyCode.LeftArrow) | Input.GetKey("a")){
            transform.Translate(-speed*Time.deltaTime,0,0);
            if(transform.localScale.x>0){
            transform.localScale=new Vector3(transform.localScale.x*-1,transform.localScale.y,transform.localScale.z);
        }
        }
        
    }
}
