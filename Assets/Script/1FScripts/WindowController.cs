using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{   
    public Animation Anim;
    int count=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player"){
            count++;
            Debug.Log("第"+count+"次經過窗戶");
            Anim.Play("Hand");
            Anim.Play("PeopleShadow");
        }
        if(count==2){
            Destroy(this.gameObject);
        }
    }
}
