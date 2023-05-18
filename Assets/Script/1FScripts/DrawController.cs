using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawController : MonoBehaviour
{
    bool touched = false;
    private Animation Anim;
    private bool Draw;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animation>();
        Draw = GameDataManager.Draw;
        if (Draw)
        {   
            transform.position = new Vector3(-20.97f, 2.9f, 0);
            transform.rotation = Quaternion.Euler(0, 0, -21.428f);
            
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && touched == false && Draw == false)
        {
            Anim.Play("DrawMove");
            Debug.Log("撞到畫了");
            touched = true;
            Draw = true;
            GameDataManager.Draw = Draw;
        }
    }
}
