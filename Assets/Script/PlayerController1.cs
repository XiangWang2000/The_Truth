using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject menu;
    public GameObject basemap;
    public GameObject instruction_rightimage;
    public GameObject item_rightimage;
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
            Player_move();
        }
        menu_display();
        menu_operate();
    }
    void Player_move(){
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
    void menu_operate(){
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
        if(count>1){
            instruction_rightimage.SetActive(false);
            item_rightimage.SetActive(false);
        }else if(count==0){
            instruction_rightimage.SetActive(true);
            item_rightimage.SetActive(false);
        }else{
            item_rightimage.SetActive(true);
            instruction_rightimage.SetActive(false);
        }
        if(count==2 && (Input.GetKeyDown(KeyCode.KeypadEnter) | Input.GetKeyDown(KeyCode.Return))){
            Debug.Log("回到標題");
            SceneManager.LoadScene("MainScene");
        }
        if(count==3 && (Input.GetKeyDown(KeyCode.KeypadEnter) | Input.GetKeyDown(KeyCode.Return))){
            Debug.Log("結束遊戲");
            Application.Quit();
        }
    }
    void menu_display(){
        if(Input.GetKeyDown(KeyCode.Escape) && menuopened==false){
            menuopened=true;
            move=false;
            GameDataManager.move=move;
            count=0;
            basemap.transform.localPosition=new Vector3(basemap.transform.localPosition.x,204,basemap.transform.localPosition.z);
            Debug.Log("停止人物移動");
            menu.SetActive(true);
        }else if(Input.GetKeyDown(KeyCode.Escape) && menuopened==true){
            menuopened=false;
            move=true;
            GameDataManager.move=true;
            Debug.Log("開始人物移動");
            menu.SetActive(false);
        }
        if(Input.GetKeyDown("b") && menuopened==false){
            menuopened=true;
            move=false;
            count=1;
            basemap.transform.localPosition=new Vector3(basemap.transform.localPosition.x,104,basemap.transform.localPosition.z);
            GameDataManager.move=move;
            Debug.Log("停止人物移動");
            menu.SetActive(true);
        }else if(Input.GetKeyDown("b") && menuopened==true){
            menuopened=false;
            move=true;
            GameDataManager.move=true;
            Debug.Log("開始人物移動");
            menu.SetActive(false);
        }
    }
}
