using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSecond : MonoBehaviour
{   
    public GameObject GrandMa;
    public GameObject Player;
    public GameObject Dot1;
    public GameObject Dot2; //玩家移動一點阿罵現身
    public SpriteRenderer sr; // 奶奶的圖像
    private bool isinGranadmaPart ;
    private bool isStartMove;
    // Start is called before the first frame update
    void Start()
    {   
        isStartMove = false;
        this.isinGranadmaPart = GameDataManager.isinGranadmaPart;
        Debug.Log(isinGranadmaPart);
    }

    // Update is called once per frame
    void Update()
    {
        if(isinGranadmaPart && isStartMove){
            GrandMa.SetActive(true);
        }
        if(Player.transform.position.x > Dot1.transform.position.x ||Player.transform.position.x < Dot2.transform.position.x ){
            isStartMove = true;
            Debug.Log("如果觸發奶奶事件，那麼奶奶該出現了");
        }
        if(Player.transform.position.x==Dot1.transform.position.x){
            sr.flipX = false;
        }
        // Debug.Log("玩家的位置"+Player.transform.position.x);
        // Debug.Log("左點的位置"+Dot1.transform.position.x);
        // Debug.Log("右點的位置"+Dot2.transform.position.x);
    }
}
