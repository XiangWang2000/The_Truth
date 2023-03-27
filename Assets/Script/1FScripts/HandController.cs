using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    bool touched = false;
    private Animation Anim;
    private int window_count;
    // Start is called before the first frame update
    void Start()
    {
        Anim = GetComponent<Animation>();
        window_count = GameDataManager.window_count;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && touched == false && window_count == 2)
        {
            Anim.Play("Hand");
            touched = true;
            window_count++;
            GameDataManager.window_count = window_count;
        }
    }
}
