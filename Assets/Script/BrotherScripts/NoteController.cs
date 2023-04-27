using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteController : MonoBehaviour
{
    private bool Note;
    private bool touched = false;
    private bool move;
    private bool read = false;
    int count = 0;
    private GameObject trig;
    private GameObject Player;
    private Image center_image;
    // Start is called before the first frame update
    void Start()
    {
        Note = GameDataManager.Note;
        move = GameDataManager.move;
        trig = GameObject.FindGameObjectWithTag("Trig");
        Player = GameObject.FindGameObjectWithTag("Player");
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
            center_image.color = new Color(1f, 1f, 1f, 1f);
            center_image.rectTransform.sizeDelta = new Vector2(1920f, 1080f);
            touched = false;
            move = false;
            GameDataManager.move = move;
            Debug.Log("停止人物移動");
            Note = true;
            GameDataManager.Note = Note;
            Debug.Log("開始對話");
            center_image.sprite = Resources.Load<Sprite>("BrotherRoomImage/介面_日記本_1");
            count++;
            read = true;
        }
        if (read)
        {
            if (Input.GetKeyDown("space"))
            {
                count++;
                if (count == 2)
                {
                    center_image.sprite = Resources.Load<Sprite>("BrotherRoomImage/介面_日記本_2");
                }
                else if (count == 3)
                {
                    center_image.sprite = Resources.Load<Sprite>("BrotherRoomImage/介面_日記本_3");
                }
                else if (count == 4)
                {
                    center_image.sprite = Resources.Load<Sprite>("BrotherRoomImage/介面_日記本_4");
                    GameDataManager.move = true;
                    center_image.color = new Color(1f, 1f, 1f, 0f);
                    Debug.Log("開始人物移動");
                    read = false;
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !GameDataManager.Note)
        {
            touched = true;
            trig.SetActive(true);
            Debug.Log("碰到筆記本");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        touched = false;
        trig.SetActive(false);
    }
}
