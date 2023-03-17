using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(speed*Time.deltaTime,0,0);
        }
        else if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Translate(-speed*Time.deltaTime,0,0);
        }
        
    }
    private void FixedUpdate(){
        rb.MovePosition(rb.position+movement*speed*Time.fixedDeltaTime);
    }
    void Move(){
        float horizontalMove = Input.GetAxis("Horizontal");
        //角色移動
        if (horizontalMove!= 0f)
        {
            rb.velocity = new Vector2(horizontalMove * speed * Time.deltaTime, rb.velocity.y);
        }
    }
}
