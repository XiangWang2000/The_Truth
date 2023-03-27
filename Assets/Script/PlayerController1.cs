using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;

public class PlayerController1 : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject menu;
    public GameObject basemap;
    public GameObject instruction_rightimage;
    public GameObject item_rightimage;
    public GameObject item_album;
    public GameObject item_rope;
    public GameObject item_pot;
    public GameObject item_blood_tissue;
    public GameObject item_tissue;
    public GameObject item_invoice;
    public GameObject zoomin;
    public Sprite album;
    public Sprite rope;
    public Sprite pot;
    public Sprite blood_tissue;
    public Sprite tissue;
    public Sprite invoice;
    public Sprite album_shadow;
    public Sprite rope_shadow;
    public Sprite pot_shadow;
    public Sprite blood_tissue_shadow;
    public Sprite tissue_shadow;
    public Sprite invoice_shadow;
    public Text item_description;
    public GameObject bag;
    public GameObject item_check;
    public float speed;
    public float runspeed;
    bool menuopened = false;
    int count = 0;
    int item_count = 0;
    private bool move;
    private bool Album;
    private bool Rope;
    private bool Pot;
    private bool Blood_Tissue;
    private bool Invoice;
    private bool Tissue;
    private float posx;
    private bool toilet_entered;
    private bool second_floor_entered;
    public CinemachineVirtualCamera cinemachineVirtualCamera;

    public Animator Animator;

    // Start is called before the first frame update
    void Start()
    {   
        Animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        menu.SetActive(false);
        zoomin.SetActive(false);
        item_check.SetActive(false);
        Album = GameDataManager.Album;
        Rope = GameDataManager.Rope;
        Pot = GameDataManager.Pot;
        Blood_Tissue = GameDataManager.Blood_Tissue;
        Invoice = GameDataManager.Invoice;
        Tissue = GameDataManager.Tissue;
        move = GameDataManager.move;
        posx = GameDataManager.posx;
        toilet_entered = GameDataManager.toilet_entered;
        second_floor_entered = GameDataManager.second_floor_entered;
        Scene scene = SceneManager.GetActiveScene();
        if ((toilet_entered == true || second_floor_entered == true) && scene.name == "FirstScene")
        {
            transform.position = new Vector3(posx, transform.position.y, transform.position.z);
            Debug.Log("從其他場景回來");
            toilet_entered = false;
            second_floor_entered = false;
            GameDataManager.toilet_entered = toilet_entered;
            GameDataManager.second_floor_entered = second_floor_entered;
        }
        Animator.SetBool("isRun",false);
        Animator.SetBool("isWalk",false);
        Animator.SetBool("isIdle",true);
    }

    // Update is called once per frame
    void Update()
    {
        move = GameDataManager.move;
        if (move)
        {
            Player_move();
        }
        menu_display();
        menu_operate();
        if (count == 1 && menuopened)
        {
            bag_operate();
        }
    }
    void Player_move()
    {
        if ((Input.GetKey(KeyCode.LeftArrow) | Input.GetKey("a")) & (Input.GetKey(KeyCode.LeftShift) | Input.GetKey(KeyCode.RightShift)))
        {
            transform.Translate(-runspeed * Time.deltaTime, 0, 0);
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            CinemachineFramingTransposer transposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
            transposer.m_TrackedObjectOffset=new Vector3(-5f,1.1f,0f);
            Animator.SetBool("isRun",true);
            Animator.SetBool("isWalk",false);
            Animator.SetBool("isIdle",false);
            Debug.Log("現在狀態為跑步");
        }
        else if ((Input.GetKey(KeyCode.RightArrow) | Input.GetKey("d")) & (Input.GetKey(KeyCode.LeftShift) | Input.GetKey(KeyCode.RightShift)))
        {
            transform.Translate(runspeed * Time.deltaTime, 0, 0);
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            CinemachineFramingTransposer transposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
            transposer.m_TrackedObjectOffset=new Vector3(5f,1.1f,0f);
            Animator.SetBool("isRun",true);
            Animator.SetBool("isWalk",false);
            Animator.SetBool("isIdle",false);
            Debug.Log("現在狀態為跑步");
        }
        else if (Input.GetKey(KeyCode.RightArrow) | Input.GetKey("d"))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            CinemachineFramingTransposer transposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
            transposer.m_TrackedObjectOffset=new Vector3(5f,1.1f,0f);
            Animator.SetBool("isRun",false);
            Animator.SetBool("isWalk",true);
            Animator.SetBool("isIdle",false);
            Debug.Log("現在狀態為走路");
        }
        else if (Input.GetKey(KeyCode.LeftArrow) | Input.GetKey("a"))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            CinemachineFramingTransposer transposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
            transposer.m_TrackedObjectOffset=new Vector3(-5f,1.1f,0f);
            Animator.SetBool("isRun",false);
            Animator.SetBool("isWalk",true);
            Animator.SetBool("isIdle",false);
            Debug.Log("現在狀態為走路");
        }else{
            Animator.SetBool("isRun",false);
            Animator.SetBool("isWalk",false);
            Animator.SetBool("isIdle",true);
            Debug.Log("現在狀態為站立");
        }
    }
    void menu_operate()
    {
        if (count < 3 && (Input.GetKeyDown(KeyCode.DownArrow) | Input.GetKeyDown("s")) && menuopened == true)
        {
            Debug.Log("按了下");
            basemap.transform.localPosition = new Vector3(basemap.transform.localPosition.x, basemap.transform.localPosition.y - 100, basemap.transform.localPosition.z);
            count++;
        }
        if (count > 0 && (Input.GetKeyDown(KeyCode.UpArrow) | Input.GetKeyDown("w")) && menuopened == true)
        {
            Debug.Log("按了上");
            basemap.transform.localPosition = new Vector3(basemap.transform.localPosition.x, basemap.transform.localPosition.y + 100, basemap.transform.localPosition.z);
            count--;
        }
        if (count == 0)
        {
            instruction_rightimage.SetActive(true);
            bag.SetActive(false);
        }
        else if (count == 1)
        {
            instruction_rightimage.SetActive(false);
            bag.SetActive(true);
            item_get();
        }
        else
        {
            instruction_rightimage.SetActive(false);
            bag.SetActive(false);
            item_description.text = "";
        }
        if (count == 2 && (Input.GetKeyDown(KeyCode.KeypadEnter) | Input.GetKeyDown(KeyCode.Return)))
        {
            Debug.Log("回到標題");
            SceneManager.LoadScene("MainScene");
        }
        else if (count == 3 && (Input.GetKeyDown(KeyCode.KeypadEnter) | Input.GetKeyDown(KeyCode.Return)))
        {
            Debug.Log("結束遊戲");
            Application.Quit();
        }
    }
    void menu_display()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && menuopened == false)
        {
            menuopened = true;
            move = false;
            GameDataManager.move = move;
            count = 0;
            basemap.transform.localPosition = new Vector3(basemap.transform.localPosition.x, 204, basemap.transform.localPosition.z);
            Debug.Log("停止人物移動");
            menu.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && menuopened == true)
        {
            menuopened = false;
            move = true;
            GameDataManager.move = move;
            item_count = 0;
            Debug.Log("開始人物移動");
            menu.SetActive(false);
        }
        if (Input.GetKeyDown("b") && menuopened == false)
        {
            menuopened = true;
            move = false;
            count = 1;
            basemap.transform.localPosition = new Vector3(basemap.transform.localPosition.x, 104, basemap.transform.localPosition.z);
            GameDataManager.move = move;
            item_get();
            bag_operate();
            Debug.Log("停止人物移動");
            menu.SetActive(true);
            bag.SetActive(true);
        }
        else if (Input.GetKeyDown("b") && menuopened == true)
        {
            menuopened = false;
            move = true;
            GameDataManager.move = true;
            item_count = 0;
            Debug.Log("開始人物移動");
            menu.SetActive(false);
        }
    }
    void item_get()
    {
        Album = GameDataManager.Album;
        Rope = GameDataManager.Rope;
        Pot = GameDataManager.Pot;
        Blood_Tissue = GameDataManager.Blood_Tissue;
        Invoice = GameDataManager.Invoice;
        Tissue = GameDataManager.Tissue;
        if (Album == true)
        {
            item_album.GetComponent<Image>().sprite = album;
        }
        else
        {
            item_album.GetComponent<Image>().sprite = album_shadow;
        }
        if (Rope == true)
        {
            item_rope.GetComponent<Image>().sprite = rope;
        }
        else
        {
            item_rope.GetComponent<Image>().sprite = rope_shadow;
        }
        if (Pot == true)
        {
            item_pot.GetComponent<Image>().sprite = pot;
        }
        else
        {
            item_pot.GetComponent<Image>().sprite = pot_shadow;
        }
        if (Blood_Tissue == true)
        {
            item_blood_tissue.GetComponent<Image>().sprite = blood_tissue;
        }
        else
        {
            item_blood_tissue.GetComponent<Image>().sprite = blood_tissue_shadow;
        }
        if (Invoice == true)
        {
            item_invoice.GetComponent<Image>().sprite = invoice;
        }
        else
        {
            item_invoice.GetComponent<Image>().sprite = invoice_shadow;
        }
        if (Tissue == true)
        {
            item_tissue.GetComponent<Image>().sprite = tissue;
        }
        else
        {
            item_tissue.GetComponent<Image>().sprite = tissue_shadow;
        }
    }
    void bag_operate()
    {
        if (count == 1 && menuopened == true)
        {
            if (item_count == 0)
            {
                item_check.SetActive(false);
                zoomin.SetActive(false);
                item_description.text = "";
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) | Input.GetKeyDown("d") && item_count < 3)
            {
                if (item_count == 0)
                {
                    item_count++;
                }
                else
                {
                    item_count++;
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) | Input.GetKeyDown("a") && item_count > 1)
            {
                item_count--;
            }
            if (item_count == 1 && Album == true)
            {
                zoomin.SetActive(true);
                zoomin.GetComponent<Image>().sprite = album;
                item_check.SetActive(true);
                item_check.transform.localPosition = new Vector3(-280, item_check.transform.localPosition.y, item_check.transform.localPosition.z);
                item_description.text = "這些相片為什麼會被收到這邊呢.....?";
            }
            else if (item_count == 2 && Rope == true)
            {
                zoomin.SetActive(true);
                zoomin.GetComponent<Image>().sprite = rope;
                item_check.SetActive(true);
                item_check.transform.localPosition = new Vector3(-100, item_check.transform.localPosition.y, item_check.transform.localPosition.z);
                item_description.text = "看起來只是一個普通的跳繩，不知道有什麼用途？";
            }
            else if (item_count == 3 && Pot == true)
            {
                zoomin.SetActive(true);
                zoomin.GetComponent<Image>().sprite = pot;
                item_check.SetActive(true);
                item_check.transform.localPosition = new Vector3(80, item_check.transform.localPosition.y, item_check.transform.localPosition.z);
                item_description.text = "一個燒焦的鍋子。\n這會是什麼重要的線索嗎？";
            }
        }
    }
}
