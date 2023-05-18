using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BedSideCabinetController : MonoBehaviour
{
    private int count;
    private bool touched = false;
    private bool move;
    private bool Insurance;
    private bool read = false;
    private bool FirstTimeGetinGrandMaRoom;
    private GameObject trig;
    private GameObject Player;
    private GameObject dialog_box;
    private Text dialog;
    private GameObject camera_position;
    private Image center_image;
    // Start is called before the first frame update
    void Start()
    {
        FirstTimeGetinGrandMaRoom = GameDataManager.FirstTimeGetinGrandMaRoom;
        if (FirstTimeGetinGrandMaRoom)
        {
            SceneManager.LoadScene("GM_room");
            FirstTimeGetinGrandMaRoom = false;
            GameDataManager.FirstTimeGetinGrandMaRoom = FirstTimeGetinGrandMaRoom;
        }
        move = GameDataManager.move;
        Insurance = GameDataManager.Insurance;
        trig = GameObject.FindGameObjectWithTag("Trig");
        Player = GameObject.FindGameObjectWithTag("Player");
        dialog_box = GameObject.FindGameObjectWithTag("Dialog_box");
        dialog = GameObject.FindGameObjectWithTag("Dialog").GetComponent<Text>();
        camera_position = GameObject.FindGameObjectWithTag("MainCamera");
        center_image = GameObject.FindGameObjectWithTag("Center_Image").GetComponent<Image>();
        center_image.color = new Color(1f, 1f, 1f, 0f);
        // trig.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (touched)
        {
            trig.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 3.5f, trig.transform.position.z);
        }
        if (Input.GetKeyDown("f") && touched == true)
        {
            Debug.Log("輸入F了");
            this.trig.SetActive(false);
            touched = false;
            move = false;
            GameDataManager.move = move;
            Debug.Log("停止人物移動");
            Debug.Log("開始對話");
            dialog_box.SetActive(true);
            dialog_box.transform.position = new Vector3(camera_position.transform.position.x, camera_position.transform.position.y - 4, dialog_box.transform.position.z);
            dialog.text = "有幾個藥罐、保健食品，假牙清潔錠...";
            count = 1;
            read = true;
        }
        if (read)
        {
            if (Input.GetKeyDown("space"))
            {
                if (count == 1)
                {
                    dialog.text = "應該是老人家的房間。";
                    if (Insurance)
                    {
                        Debug.Log("已經拿過道具囉");
                        count = 4;
                    }
                }
                else if (count == 2)
                {
                    dialog.text = "抽屜裡找到了保單。";
                    center_image.color = new Color(1f, 1f, 1f, 1f);
                    center_image.rectTransform.sizeDelta = new Vector2(300f, 300f);
                    center_image.sprite = Resources.Load<Sprite>("Bag/保單");
                    Insurance = true;
                    GameDataManager.Insurance = Insurance;
                }
                else if (count == 3)
                {
                    dialog.text = "這幾張的保險金受益人看起來都是男生的名字。";
                }
                else if (count == 4)
                {
                    dialog.text = "是不想讓女生拿錢的那種戲碼嗎？";
                }
                else if (count == 5)
                {
                    dialog.text = "";
                    GameDataManager.move = true;
                    Debug.Log("開始人物移動");
                    center_image.color = new Color(1f, 1f, 1f, 0f);
                    dialog_box.SetActive(false);
                    read = false;
                }
                count++;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            touched = true;
            trig.SetActive(true);
            Debug.Log("碰到床頭櫃");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        touched = false;
        trig.SetActive(false);
    }
}
