using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GarderobeController : MonoBehaviour
{
    private int count = 0;
    private bool touched = false;
    private bool move;
    private bool read = false;
    private GameObject trig;
    private GameObject Player;
    private GameObject dialog_box;
    private Text dialog;
    private GameObject camera_position;
    // Start is called before the first frame update
    void Start()
    {
        move = GameDataManager.move;
        trig = GameObject.FindGameObjectWithTag("Trig");
        Player = GameObject.FindGameObjectWithTag("Player");
        dialog_box = GameObject.FindGameObjectWithTag("Dialog_box");
        dialog = GameObject.FindGameObjectWithTag("Dialog").GetComponent<Text>();
        camera_position = GameObject.FindGameObjectWithTag("MainCamera");
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
            dialog.text = "沒什麼特別的。";
            count++;
            read = true;
        }
        if (read)
        {
            if (Input.GetKeyDown("space"))
            {
                if (count == 1)
                {
                    dialog.text = "嗯⋯⋯風格很長輩。";
                }
                else if (count == 2)
                {
                    dialog.text = "";
                    GameDataManager.move = true;
                    Debug.Log("開始人物移動");
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
            Debug.Log("碰到衣櫃");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        touched = false;
        trig.SetActive(false);
    }
}
