using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public Vector3 m_FollowOffset;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(" "+transform.GetComponentInChildren<CinemachineFramingTransposer>());
        transform.GetComponentInChildren<CinemachineFramingTransposer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
