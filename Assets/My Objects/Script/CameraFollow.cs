using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Player;
    public float Smoothing;

    void Start()
    {
        
    }

    private void LateUpdate()
    {
        if(Player != null)
        {
            if(transform.position != Player.position)
            {
                Vector3 TargetPos = Player.position;
                transform.position = Vector3.Lerp(transform.position, TargetPos, Smoothing);
            }
        }
    }

    void Update()
    {
        
    }
}
