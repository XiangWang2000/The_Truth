using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorController : MonoBehaviour
{
    public GameObject trig;

    public Animation Anim;

    private bool MirrorBlood;

    public GameObject Blood;
    // Start is called before the first frame update
    void Start()
    {
        MirrorBlood = GameDataManager.MirrorBlood;
        if (MirrorBlood)
        {   
            Debug.Log("設定初始位置");
            Debug.Log(Blood.transform.position);
            Blood.transform.position = new Vector3(-3.57f,1.6f,0);
            // transform.rotation = Quaternion.Euler(0, 0, -21.428f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !MirrorBlood)
        {   
            MirrorBlood = true;
            GameDataManager.MirrorBlood = MirrorBlood;
            Anim.Play("MirrorBlood");
            Debug.Log("碰到鏡子");
        }
    }
}
