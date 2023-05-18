using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RopeController : MonoBehaviour
{
    public GameObject trig;
    public GameObject dialog_box;
    public GameObject camera_position;
    public GameObject draw;
    public GameObject Player;
    public Text dialog;
    private int count = 0;
    private bool take = false;
    private bool touched = false;
    private bool read = false;
    private bool move;
    private bool Rope;
    // Start is called before the first frame update
    void Start()
    {
        this.trig.SetActive(false);
        this.dialog_box.SetActive(false);
        this.draw.SetActive(false);
        move = GameDataManager.move;
        Rope = GameDataManager.Rope;
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
            this.dialog_box.SetActive(true);
            this.draw.SetActive(true);
            // Debug.Log(camera_position.transform.position.y);
            this.dialog_box.transform.position = new Vector3(camera_position.transform.position.x, camera_position.transform.position.y - 3, dialog_box.transform.position.z);
            this.draw.transform.position = new Vector3(camera_position.transform.position.x, camera_position.transform.position.y, draw.transform.position.z);
            take = true;
            touched = false;
            move = false;
            read = true;
            GameDataManager.move = move;
            Debug.Log("停止人物移動");
            Debug.Log("開始對話");
            dialog.text = "看起來只是一個普通的跳繩，不知道有什麼用途？";
            count++;
            Rope = true;
            GameDataManager.Rope = Rope;
        }
        if (read && take == true)
        {

            if (Input.GetKeyDown("space"))
            {
                if (count == 1)
                {
                    dialog.text = "";
                    move = true;
                    GameDataManager.move = true;
                    Debug.Log("開始人物移動");
                    this.draw.SetActive(false);
                    this.dialog_box.SetActive(false);
                    read = false;
                }
                count++;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && take == false && Rope == false)
        {
            this.trig.SetActive(true);
            Debug.Log("碰到繩子了");
            touched = true;
        }


    }
    private void OnTriggerExit2D(Collider2D other)
    {
        this.trig.SetActive(false);
        touched = false;
    }
}
