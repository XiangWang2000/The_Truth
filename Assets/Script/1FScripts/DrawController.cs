using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawController : MonoBehaviour
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
            Anim.Play("DrawMove");
            Debug.Log("撞到畫了");
            touched = true;
        }
    }
}
