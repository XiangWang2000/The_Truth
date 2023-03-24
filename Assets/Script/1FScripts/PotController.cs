using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotController : MonoBehaviour
{
    public GameObject trig;
    public GameObject dialog_box;
    public GameObject camera;
    public GameObject draw;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("f") && touched == true)
        {
            Debug.Log("輸入F了");
            this.trig.SetActive(false);
            //Destroy(this.gameObject);
            this.dialog_box.SetActive(true);
            this.draw.SetActive(true);
            // Debug.Log(camera.transform.position.y);
            this.dialog_box.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y - 3, dialog_box.transform.position.z);
            this.draw.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, draw.transform.position.z);
            take = true;
            touched = false;
            move = false;
            GameDataManager.move = move;
            Debug.Log("停止人物移動");
            Debug.Log("開始對話");
        }
        if (read == false && take == true)
        {
            if (count == 0)
            {
                Pot = true;
                GameDataManager.Pot = Pot;
                dialog.text = "獲得道具「燒焦的鍋子」：";
                count++;
            }
            if (Input.GetKeyDown("space"))
            {
                if (count == 1)
                {
                    dialog.text = "「這會是什麼重要的線索嗎？」";
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
