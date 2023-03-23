using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject menu;
    public GameObject basemap;
    public float speed;
    public float runspeed;
    bool menuopened=false;
    int count=0;
    private bool move;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        menu.SetActive(false);
        move=GameDataManager.move;
    }

    // Update is called once per frame
    void Update()
    {
        move=GameDataManager.move;
        if(move){
            if((Input.GetKey(KeyCode.LeftArrow) | Input.GetKey("a")) & (Input.GetKey(KeyCode.LeftShift)|Input.GetKey(KeyCode.RightShift))){
                transform.Translate(-runspeed*Time.deltaTime,0,0);
                if(transform.localScale.x>0){
                    transform.localScale=new Vector3(transform.localScale.x*-1,transform.localScale.y,transform.localScale.z);
                }
            }else if((Input.GetKey(KeyCode.RightArrow) | Input.GetKey("d")) & (Input.GetKey(KeyCode.LeftShift)|Input.GetKey(KeyCode.RightShift))){
                transform.Translate(runspeed*Time.deltaTime,0,0);
                if(transform.localScale.x<0){
                    transform.localScale=new Vector3(transform.localScale.x*-1,transform.localScale.y,transform.localScale.z);
                }
            }else if(Input.GetKey(KeyCode.RightArrow) | Input.GetKey("d")){
                transform.Translate(speed*Time.deltaTime,0,0);
                if(transform.localScale.x<0){
                    transform.localScale=new Vector3(transform.localScale.x*-1,transform.localScale.y,transform.localScale.z);
                }
            }
            else if(Input.GetKey(KeyCode.LeftArrow) | Input.GetKey("a")){
                transform.Translate(-speed*Time.deltaTime,0,0);
                if(transform.localScale.x>0){
                    transform.localScale=new Vector3(transform.localScale.x*-1,transform.localScale.y,transform.localScale.z);
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape) && menuopened==false){
            menuopened=true;
            move=false;
            GameDataManager.move=move;
            Debug.Log("停止人物移動");
            menu.SetActive(true);
        }else if(Input.GetKeyDown(KeyCode.Escape) && menuopened==true){
            menuopened=false;
            move=true;
            GameDataManager.move=true;
            Debug.Log("開始人物移動");
            menu.SetActive(false);
        }
        if(count<3 && (Input.GetKeyDown(KeyCode.DownArrow) | Input.GetKeyDown("s")) && menuopened==true){
            Debug.Log("按了下");
            basemap.transform.localPosition=new Vector3(basemap.transform.localPosition.x,basemap.transform.localPosition.y-100,basemap.transform.localPosition.z);
            count++;
        }
        if(count>0 && (Input.GetKeyDown(KeyCode.UpArrow) | Input.GetKeyDown("w")) && menuopened==true){
            Debug.Log("按了上");
            basemap.transform.localPosition=new Vector3(basemap.transform.localPosition.x,basemap.transform.localPosition.y+100,basemap.transform.localPosition.z);
            count--;
        }
    }
}
