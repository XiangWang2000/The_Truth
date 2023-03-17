using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_TEST1 : MonoBehaviour
{
    public float WalkSpeed = 0.01f;
    public float RunSpeed = 0.04f;
    public float Dis = 1000;
    public Transform Target;


    void Start()
    {

    }

    void Update()
    {

        if (Input.GetMouseButton(0))//滑鼠持續輸入左鍵（按住）0左鍵；1右鍵；2中鍵
        {
            float dis = Vector2.Distance(Input.mousePosition, Target.position);
            print("距離是：" + dis);

            if (dis >= Dis)
            {
                this.gameObject.transform.position += new Vector3(RunSpeed, 0, 0);
            }
            else
            {
                this.gameObject.transform.position += new Vector3(WalkSpeed, 0, 0);
            }

        }

        

    }
}


