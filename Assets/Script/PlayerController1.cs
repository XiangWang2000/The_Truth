using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    public GameObject AlbumTrig;
    public GameObject RopeTrig;
    public GameObject BloodTrig;
    public GameObject PotTrig;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bool album=true;
        bool rope=true;
        bool blood=true;
        bool draw=true;
        bool pot=true;
        this.AlbumTrig.SetActive(false);
        this.RopeTrig.SetActive(false);
        this.BloodTrig.SetActive(false);
        this.PotTrig.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow | KeyCode.D)){
            transform.Translate(speed*Time.deltaTime,0,0);
        }
        else if(Input.GetKey(KeyCode.LeftArrow | KeyCode.A)){
            transform.Translate(-speed*Time.deltaTime,0,0);
        }
        
    }
    // private void FixedUpdate(){
    //     rb.MovePosition(rb.position+movement*speed*Time.fixedDeltaTime);
    // }
    void OnTriggerEnter2D(Collider2D other) {
        touched(other.gameObject.tag);
    }
    void OnTriggerExit2D(Collider2D other) {
        
    }
    void touched(string tag){
        if(tag=="Album"){
            this.AlbumTrig.SetActive(true);
            if(Input.GetKey(KeyCode.F)){

            }
        }
        else if(tag=="Rope"){

        }else if(tag=="Blood"){

        }else if(tag=="Draw"){

        }else if(tag=="Pot"){

        }
    }
}
