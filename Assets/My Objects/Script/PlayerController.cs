using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float WalkSpeed = 0.01f;
    public float RunSpeed = 0.04f;
    private bool Turn = false;


    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (Turn == true)
        {
            this.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Turn == false)
        {
            this.transform.eulerAngles = new Vector3(0, 0, 0);
        }


        if (Input.GetKey(KeyCode.RightArrow))
        {
            Turn = false;

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                this.gameObject.transform.position += new Vector3(RunSpeed, 0, 0);
            }
            else
            {
                this.gameObject.transform.position += new Vector3(WalkSpeed, 0, 0);
            }
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Turn = true;

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                this.gameObject.transform.position -= new Vector3(RunSpeed, 0, 0);
            }
            else
            {
                this.gameObject.transform.position -= new Vector3(WalkSpeed, 0, 0);
            }
        }

    }
}
