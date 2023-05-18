using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotController : MonoBehaviour
{
    public GameObject trig;
    public GameObject dialog_box;
    public GameObject camera_position;
    public GameObject draw;
    public GameObject Player;
    public Text dialog;
    int count = 0;
    bool take = false;
    bool touched = false;
    bool read = false;
    private bool move;
    private bool Pot;
    // Start is called before the first frame update
    void Start()
    {
        this.trig.SetActive(false);
        this.dialog_box.SetActive(false);
        this.draw.SetActive(false);
        move = GameDataManager.move;
        Pot = GameDataManager.Pot;
        if (Pot == true)
        {
            Destroy(this.gameObject);
        }
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
            //Destroy(this.gameObject);
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
            Pot = true;
            GameDataManager.Pot = Pot;
            count++;
        }
        if (read == false && take == true)
        {
            if (Input.GetKeyDown("space"))
            {
                if (count == 1)
                {
                    dialog.text = "這會是什麼重要的線索嗎？";
                }
                else if (count == 2)
                {
                    dialog.text = "";
                    this.draw.SetActive(false);
                    this.dialog_box.SetActive(false);
                    this.gameObject.SetActive(false);
                    move = true;
                    GameDataManager.move = true;
                    Debug.Log("開始人物移動");
                    read = true;
                }
                count++;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && take == false)
        {
            this.trig.SetActive(true);
            Debug.Log("碰到鍋子了");
            touched = true;
        }


    }
    private void OnTriggerExit2D(Collider2D other)
    {
        this.trig.SetActive(false);
        touched = false;
    }
}
