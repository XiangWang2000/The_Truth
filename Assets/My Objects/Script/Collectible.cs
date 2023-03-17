using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Collectible : MonoBehaviour
{
    public string ChatName;

    //是否可以對話
    private bool canChat = false;

    void Start()
    {

    }

    //於觸發範圍內
    private void OnTriggerEnter(Collider other)
    {
        canChat = true;
    }
    //於觸發範圍外
    private void OnTriggerExit(Collider other)
    {
        canChat = false;
    }

    void Update()
    {
        //按下「F」鍵執行 Say()
        if (Input.GetKeyDown(KeyCode.F))
        {
            Say();
        }
    }

    void Say()
    {
        if (canChat)
        {
            //在場景中找到該物件
            Flowchart flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();

            //有這個對話（ChatName）存在的話執行對話
            if (flowchart.HasBlock(ChatName))
            {
                flowchart.ExecuteBlock(ChatName);
                //Destroy(this.gameObject);
            }
        }
    }
}
