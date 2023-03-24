using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlbumController : MonoBehaviour
{
    public GameObject trig;
    public GameObject dialog_box;
    public GameObject camera_position;
    public GameObject draw;
    public Text dialog;
    int count = 0;
    bool take = false;
    bool touched = false;
    bool read = false;
    private bool move;
    private bool Album;
    // Start is called before the first frame update
    void Start()
    {
        this.trig.SetActive(false);
        this.dialog_box.SetActive(false);
        this.draw.SetActive(false);
        move = GameDataManager.move;
        Album = GameDataManager.Album;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f") && touched == true)
        {
            Debug.Log("輸入F了");
            this.trig.SetActive(false);
            this.dialog_box.SetActive(true);
            this.draw.SetActive(true);
            // Debug.Log(camera_position.transform.position.y);
            this.dialog_box.transform.position = new Vector3(camera_position.transform.position.x, camera_position.transform.position.y - 3, dialog_box.transform.position.z);
            this.draw.transform.position = new Vector3(camera_position.transform.position.x, camera_position.transform.position.y, draw.transform.position.z);
            take = true;
            touched = false;
            move = false;
            GameDataManager.move = move;
            Debug.Log("停止人物移動");
            Debug.Log("開始對話");
            if (count == 0)
            {
                dialog.text = "獲得道具「一箱相簿」：";
                count++;
                Album = true;
                GameDataManager.Album = Album;
            }
        }
        if (read == false && take == true)
        {
            if (Input.GetKeyDown("space"))
            {
                if (count == 1)
                {
                    this.draw.SetActive(false);
                    dialog.text = "「在大酒櫃的最下層找到了放滿相簿的紙箱。」";
                }
                else if (count == 2)
                {
                    dialog.text = "「裡面幾乎都是一對情侶的照片，甚至還有婚紗照⋯⋯」";
                }
                else if (count == 3)
                {
                    dialog.text = "「或許房子的男主人與女主人感情不太好？」";
                }
                else if (count == 4)
                {
                    dialog.text = "";
                    move = true;
                    GameDataManager.move = true;
                    Debug.Log("開始人物移動");
                    this.dialog_box.SetActive(false);
                    read = true;
                }
                count++;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && take == false && Album == false)
        {
            this.trig.SetActive(true);
            Debug.Log("碰到相簿了");
            touched = true;
        }


    }
    private void OnTriggerExit2D(Collider2D other)
    {
        this.trig.SetActive(false);
        touched = false;
    }
}
