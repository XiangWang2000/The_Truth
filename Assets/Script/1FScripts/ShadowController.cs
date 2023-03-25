using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour
{   
    bool touched = false;
    private Animation Anim;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && touched == false)
        {
            Anim.Play("PeopleShadow");
            touched = true;
        }
    }
}
