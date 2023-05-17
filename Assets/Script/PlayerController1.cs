using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Cinemachine;
using System;

public class PlayerController1 : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject menu;
    public GameObject basemap;
    public GameObject instruction_rightimage;
    public GameObject item_album;
    public GameObject item_rope;
    public GameObject item_pot;
    public GameObject item_blood_tissue;
    public GameObject item_tissue;
    public GameObject item_invoice;
    public GameObject item_key;
    public GameObject item_note;
    public GameObject zoomin;
    public Text item_description;
    public GameObject bag;
    public GameObject item_check;
    private Image center_image;
    public float speed;
    public float runspeed;
    bool menuopened = false;
    int count = 0;
    int item_count = 0;
    private int note_page;
    private bool move;
    private bool Album;
    private bool Rope;
    private bool Pot;
    private bool Blood_Tissue;
    private bool Invoice;
    private bool Tissue;
    private bool Key;
    private bool Note;
    private bool note_show = false;
    private float posx;
    private bool toilet_entered;
    private bool second_floor_entered;
    private bool brother_room_entered;
    private bool parent_room_entered;
    private bool grandmom_room_entered;
    private bool drama_played;
    public CinemachineVirtualCamera cinemachineVirtualCamera;
    private Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        menu.SetActive(false);
        zoomin.SetActive(false);
        item_check.SetActive(false);
        try
        {
            center_image = GameObject.FindGameObjectWithTag("Center_Image").GetComponent<Image>();
            center_image.color = new Color(1f, 1f, 1f, 0f);
        }
        catch
        {

        }
        Album = GameDataManager.Album;
        Rope = GameDataManager.Rope;
        Pot = GameDataManager.Pot;
        Blood_Tissue = GameDataManager.Blood_Tissue;
        Invoice = GameDataManager.Invoice;
        Tissue = GameDataManager.Tissue;
        Key = GameDataManager.Key;
        Note = GameDataManager.Note;
        move = GameDataManager.move;
        posx = GameDataManager.posx;
        toilet_entered = GameDataManager.toilet_entered;
        second_floor_entered = GameDataManager.second_floor_entered;
        brother_room_entered = GameDataManager.brother_room_entered;
        parent_room_entered = GameDataManager.parent_room_entered;
        grandmom_room_entered = GameDataManager.grandmom_room_entered;
        drama_played = GameDataManager.drama_played;
        Scene scene = SceneManager.GetActiveScene();
        if ((toilet_entered || second_floor_entered || drama_played) && scene.name == "FirstScene")
        {
            transform.position = new Vector3(posx, transform.position.y, transform.position.z);
            Debug.Log("從其他場景回來");
            toilet_entered = false;
            second_floor_entered = false;
            drama_played = false;
            GameDataManager.toilet_entered = toilet_entered;
            GameDataManager.second_floor_entered = second_floor_entered;
            GameDataManager.drama_played = drama_played;
        }
        if ((brother_room_entered || parent_room_entered || grandmom_room_entered) && scene.name == "SecondScene")
        {
            transform.position = new Vector3(posx, transform.position.y, transform.position.z);
            Debug.Log("從其他場景回來");
            brother_room_entered = false;
            parent_room_entered = false;
            grandmom_room_entered = false;
            GameDataManager.brother_room_entered = brother_room_entered;
            GameDataManager.parent_room_entered = parent_room_entered;
            GameDataManager.grandmom_room_entered = grandmom_room_entered;
        }
        Animator.SetBool("isRun", false);
        Animator.SetBool("isWalk", false);
        Animator.SetBool("isIdle", true);
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
            transposer.m_TrackedObjectOffset = new Vector3(-5f, 1.1f, 0f);
            Animator.SetBool("isRun", true);
            Animator.SetBool("isWalk", false);
            Animator.SetBool("isIdle", false);
            // Debug.Log("現在狀態為跑步");
        }
        else if ((Input.GetKey(KeyCode.RightArrow) | Input.GetKey("d")) & (Input.GetKey(KeyCode.LeftShift) | Input.GetKey(KeyCode.RightShift)))
        {
            transform.Translate(runspeed * Time.deltaTime, 0, 0);
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            CinemachineFramingTransposer transposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
            transposer.m_TrackedObjectOffset = new Vector3(5f, 1.1f, 0f);
            Animator.SetBool("isRun", true);
            Animator.SetBool("isWalk", false);
            Animator.SetBool("isIdle", false);
            // Debug.Log("現在狀態為跑步");
        }
        else if (Input.GetKey(KeyCode.RightArrow) | Input.GetKey("d"))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            CinemachineFramingTransposer transposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
            transposer.m_TrackedObjectOffset = new Vector3(5f, 1.1f, 0f);
            Animator.SetBool("isRun", false);
            Animator.SetBool("isWalk", true);
            Animator.SetBool("isIdle", false);
            // Debug.Log("現在狀態為走路");
        }
        else if (Input.GetKey(KeyCode.LeftArrow) | Input.GetKey("a"))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
            CinemachineFramingTransposer transposer = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
            transposer.m_TrackedObjectOffset = new Vector3(-5f, 1.1f, 0f);
            Animator.SetBool("isRun", false);
            Animator.SetBool("isWalk", true);
            Animator.SetBool("isIdle", false);
            // Debug.Log("現在狀態為走路");
        }
        else
        {
            Animator.SetBool("isRun", false);
            Animator.SetBool("isWalk", false);
            Animator.SetBool("isIdle", true);
            // Debug.Log("現在狀態為站立");
        }
    }
    void menu_operate()
    {
        if (!note_show)
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
        }
        if (count == 0)
        {
            instruction_rightimage.SetActive(true);
            bag.SetActive(false);
            item_count = 0;
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
            item_count = 0;
            item_description.text = "";
        }
        if (count == 2 && (Input.GetKeyDown(KeyCode.KeypadEnter) | Input.GetKeyDown(KeyCode.Return)))
        {
            Debug.Log("回到標題");
            datasave();
            SceneManager.LoadScene("MainScene");
        }
        else if (count == 3 && (Input.GetKeyDown(KeyCode.KeypadEnter) | Input.GetKeyDown(KeyCode.Return)))
        {
            Debug.Log("結束遊戲");
            datasave();
            Application.Quit();
        }
    }
    void datasave()
    {
        PlayerPrefs.SetInt("state", GameDataManager.state);
        PlayerPrefs.SetInt("Rope", convert(GameDataManager.Rope));
        PlayerPrefs.SetInt("Album", convert(GameDataManager.Album));
        PlayerPrefs.SetInt("Pot", convert(GameDataManager.Pot));
        PlayerPrefs.SetInt("Blood_Tissue", convert(GameDataManager.Blood_Tissue));
        PlayerPrefs.SetInt("Invoice", convert(GameDataManager.Invoice));
        PlayerPrefs.SetInt("Tissue", convert(GameDataManager.Tissue));
        PlayerPrefs.SetInt("Draw", convert(GameDataManager.Draw));
        PlayerPrefs.SetInt("Key", convert(GameDataManager.Key));
        PlayerPrefs.SetInt("Note", convert(GameDataManager.Note));
        PlayerPrefs.SetInt("move", convert(GameDataManager.move));
        PlayerPrefs.SetInt("dad_dead", convert(GameDataManager.dad_dead));
        PlayerPrefs.SetFloat("posx", GameDataManager.posx);
        PlayerPrefs.SetInt("toilet_entered", convert(GameDataManager.toilet_entered));
        PlayerPrefs.SetInt("second_floor_entered", convert(GameDataManager.second_floor_entered));
        PlayerPrefs.SetInt("brother_room_entered", convert(GameDataManager.brother_room_entered));
        PlayerPrefs.SetInt("parent_room_entered", convert(GameDataManager.parent_room_entered));
        PlayerPrefs.SetInt("grandmom_room_entered", convert(GameDataManager.grandmom_room_entered));
        PlayerPrefs.SetInt("drama_played", convert(GameDataManager.drama_played));
        PlayerPrefs.SetInt("window_count", GameDataManager.window_count);
        PlayerPrefs.SetInt("MirrorBlood", convert(GameDataManager.MirrorBlood));
        PlayerPrefs.SetInt("isinGranadmaPart", convert(GameDataManager.isinGranadmaPart));
        PlayerPrefs.SetInt("GrandMaCanDie", convert(GameDataManager.GrandMaCanDie));
        PlayerPrefs.SetInt("FirstTimeGetinGrandMaRoom", convert(GameDataManager.FirstTimeGetinGrandMaRoom));
    }
    int convert(bool param)
    {
        return Convert.ToInt32(param);
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
            count = 0;
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
            count = 0;
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
        Key = GameDataManager.Key;
        Note = GameDataManager.Note;
        if (count == 1)
        {
            if (Album)
            {
                item_album.GetComponent<Image>().sprite = Resources.Load<Sprite>("Bag/塵封相簿");
            }
            else
            {
                item_album.GetComponent<Image>().sprite = Resources.Load<Sprite>("Bag/剪影_塵封相簿");
            }
            if (Rope)
            {
                item_rope.GetComponent<Image>().sprite = Resources.Load<Sprite>("Bag/跳繩");
            }
            else
            {
                item_rope.GetComponent<Image>().sprite = Resources.Load<Sprite>("Bag/剪影_跳繩");
            }
            if (Pot)
            {
                item_pot.GetComponent<Image>().sprite = Resources.Load<Sprite>("Bag/燒焦鍋子");
            }
            else
            {
                item_pot.GetComponent<Image>().sprite = Resources.Load<Sprite>("Bag/剪影_燒焦鍋子");
            }
            if (Blood_Tissue)
            {
                item_blood_tissue.GetComponent<Image>().sprite = Resources.Load<Sprite>("Bag/染血衛生紙");
            }
            else
            {
                item_blood_tissue.GetComponent<Image>().sprite = Resources.Load<Sprite>("Bag/剪影_染血衛生紙");
            }
            if (Invoice)
            {
                item_invoice.GetComponent<Image>().sprite = Resources.Load<Sprite>("Bag/旅館發票");
            }
            else
            {
                item_invoice.GetComponent<Image>().sprite = Resources.Load<Sprite>("Bag/剪影_旅館發票");
            }
            if (Tissue)
            {
                item_tissue.GetComponent<Image>().sprite = Resources.Load<Sprite>("Bag/衛生紙");
            }
            else
            {
                item_tissue.GetComponent<Image>().sprite = Resources.Load<Sprite>("Bag/剪影_衛生紙");
            }
            if (Key)
            {
                item_key.GetComponent<Image>().sprite = Resources.Load<Sprite>("Bag/鑰匙");
            }
            else
            {
                item_key.GetComponent<Image>().sprite = Resources.Load<Sprite>("Bag/剪影_鑰匙");
            }
            if (Note)
            {
                item_note.GetComponent<Image>().sprite = Resources.Load<Sprite>("Bag/日記");
            }
            else
            {
                item_note.GetComponent<Image>().sprite = Resources.Load<Sprite>("Bag/剪影_日記");
            }
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
            if (Input.GetKeyDown(KeyCode.RightArrow) | Input.GetKeyDown("d") && item_count < 8 && !note_show)
            {
                item_count++;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) | Input.GetKeyDown("a") && item_count > 1 && !note_show)
            {
                item_count--;
            }
            if (item_count == 1 && Album == true)
            {
                zoomin.SetActive(true);
                zoomin.GetComponent<Image>().sprite = Resources.Load<Sprite>("Bag/塵封相簿");
                item_check.SetActive(true);
                item_check.transform.localPosition = new Vector3(-280, item_check.transform.localPosition.y, item_check.transform.localPosition.z);
                item_description.text = "在大酒櫃的最下層找到了放滿相簿的紙箱。裡面幾乎都是一對情侶的照片，甚至還有婚紗照⋯⋯";
            }
            else if (item_count == 2 && Rope == true)
            {
                zoomin.SetActive(true);
                zoomin.GetComponent<Image>().sprite = Resources.Load<Sprite>("Bag/跳繩");
                item_check.SetActive(true);
                item_check.transform.localPosition = new Vector3(-100, item_check.transform.localPosition.y, item_check.transform.localPosition.z);
                item_description.text = "看起來只是一個普通的跳繩，不知道有什麼用途？";
            }
            else if (item_count == 3 && Pot == true)
            {
                zoomin.SetActive(true);
                zoomin.GetComponent<Image>().sprite = Resources.Load<Sprite>("Bag/燒焦鍋子");
                item_check.SetActive(true);
                item_check.transform.localPosition = new Vector3(80, item_check.transform.localPosition.y, item_check.transform.localPosition.z);
                item_description.text = "一個燒焦的鍋子。\n這會是什麼重要的線索嗎？";
            }
            else if (item_count == 4 && Note == true)
            {
                zoomin.SetActive(true);
                zoomin.GetComponent<Image>().sprite = Resources.Load<Sprite>("Bag/日記");
                item_check.SetActive(true);
                item_check.transform.localPosition = new Vector3(-280, item_check.transform.localPosition.y - 143, item_check.transform.localPosition.z);
                item_description.text = "這本日記裡面好像有寫些東西";
                if ((Input.GetKeyDown(KeyCode.KeypadEnter) | Input.GetKeyDown(KeyCode.Return)))
                {
                    if (note_show)
                    {
                        center_image.color = new Color(1f, 1f, 1f, 0f);
                        Debug.Log("關閉筆記本檢視");
                        note_show = false;
                    }
                    else
                    {
                        center_image.color = new Color(1f, 1f, 1f, 1f);
                        center_image.rectTransform.sizeDelta = new Vector2(1920f, 1080f);
                        note_page = 1;
                        center_image.sprite = Resources.Load<Sprite>("BrotherRoomImage/介面_日記本_" + note_page);
                        Debug.Log("開啟筆記本檢視");
                        Debug.Log("筆記本" + note_page);
                        note_show = true;
                    }
                }
                if (note_show)
                {
                    if ((Input.GetKeyDown(KeyCode.RightArrow) | Input.GetKeyDown("d")) && (note_page < 4))
                    {
                        note_page++;
                        Debug.Log("按下右 " + "筆記本" + note_page);
                        center_image.sprite = Resources.Load<Sprite>("BrotherRoomImage/介面_日記本_" + note_page);
                    }
                    if ((Input.GetKeyDown(KeyCode.LeftArrow) | Input.GetKeyDown("a")) && (note_page > 1))
                    {
                        note_page--;
                        Debug.Log("按下左 " + "筆記本" + note_page);
                        center_image.sprite = Resources.Load<Sprite>("BrotherRoomImage/介面_日記本_" + note_page);
                    }
                }
            }
        }
    }
}
