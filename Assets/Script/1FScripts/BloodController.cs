using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodController : MonoBehaviour
{
    public GameObject trig;
    public GameObject dialog_box;
    public GameObject camera_position;
    public Text dialog;
    int count = 0;
    bool take = false;
    bool touched = false;
    bool read = false;
    private bool move;
    // Start is called before the first frame update
    void Start()
    {
        this.trig.SetActive(false);
        this.dialog_box.SetActive(false);
        move = GameDataManager.move;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("f") && touched == true)
        {
            Debug.Log("輸入F了");
            this.trig.SetActive(false);
            this.dialog_box.SetActive(true);
            // Debug.Log(camera_position.transform.position.y);
            this.dialog_box.transform.position = new Vector3(camera_position.transform.position.x, camera_position.transform.position.y - 3, dialog_box.transform.position.z);
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
                dialog.text = "「乾掉的血跡，令人發毛⋯⋯」";
                count++;
            }
            if (Input.GetKeyDown("space"))
            {
                if (count == 1)
                {
                    dialog.text = "「是有人在這裡跌倒嗎？」";
                }
                else if (count == 2)
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
        if (other.gameObject.tag == "Player" && take == false)
        {
            this.trig.SetActive(true);
            Debug.Log("碰到血跡了");
            touched = true;
        }


    }
    private void OnTriggerExit2D(Collider2D other)
    {
        this.trig.SetActive(false);
        touched = false;
    }
}
