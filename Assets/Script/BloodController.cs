using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodController : MonoBehaviour
{
    public GameObject trig;
    bool take=false;
    bool touched=false;
    // Start is called before the first frame update
    void Start()
    {
        this.trig.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("f") && touched==true){
            Debug.Log("輸入F了");
            this.trig.SetActive(false);
            take=true;
            touched=false;
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player" && take==false){
            this.trig.SetActive(true);
            Debug.Log("碰到血跡了");
            touched=true;
        }
        
        
    }
    private void OnTriggerExit2D(Collider2D other) {
        this.trig.SetActive(false);
        touched=false;
    }
}
