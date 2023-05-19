using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AlbumController : MonoBehaviour
{
    public GameObject trig;
    public GameObject dialog_box;
    public GameObject camera_position;
    public GameObject draw;
    private GameObject Player;
    private float posx;
    private float timer = 0;
    public Text dialog;
    private int count = 0;
    private bool take = false;
    private bool touched = false;
    private bool read = false;
    private bool move;
    private bool Album;
    private bool drama_played;
    // Start is called before the first frame update
    void Start()
    {
        this.trig.SetActive(false);
        this.dialog_box.SetActive(false);
        this.draw.SetActive(false);
        move = GameDataManager.move;
        Album = GameDataManager.Album;
        posx = GameDataManager.posx;
        Player = GameObject.FindGameObjectWithTag("Player");
        drama_played = GameDataManager.drama_played;
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
            dialog.text = "在大酒櫃的最下層找到了放滿相簿的紙箱。";
            count++;
            Album = true;
            GameDataManager.Album = Album;
        }
        if (read && take)
        {
            if (Input.GetKeyDown("space"))
            {
                count++;
                if (count == 2)
                {
                    dialog.text = "裡面幾乎都是一對情侶的照片，甚至還有婚紗照⋯⋯";
                }
                else if (count == 3)
                {
                    dialog.text = "或許房子的男主人與女主人感情不太好？";
                }
                else if (count == 4)
                {
                    dialog.text = "";
                    this.draw.SetActive(false);
                    move = true;
                    GameDataManager.move = move;
                    posx = Player.transform.position.x;
                    GameDataManager.posx = posx;
                    drama_played = true;
                    GameDataManager.drama_played = drama_played;
                    Debug.Log("開始人物移動");
                    this.dialog_box.SetActive(false);
                    read = false;
                    SceneManager.LoadScene("Album");
                }
            }
        }
        if (timer < 2)
        {
            timer += Time.deltaTime;
        }
        if (GameDataManager.backfromalbum && timer > 2 && drama_played)
        {
            if (count == 0)
            {
                this.dialog_box.SetActive(true);
                this.dialog_box.transform.position = new Vector3(camera_position.transform.position.x, camera_position.transform.position.y - 3, dialog_box.transform.position.z);
                move = false;
                GameDataManager.move = move;
                Debug.Log("停止人物移動");
                dialog.text = "⋯⋯";
            }
            if (Input.GetKeyDown("space"))
            {
                count++;
                if (count == 1)
                {
                    dialog.text = "？？？";
                }
                else if (count == 2)
                {
                    dialog.text = "什麼鬼⋯⋯";
                }
                else if (count == 3)
                {
                    dialog.text = "剛剛是什麼畫面？是誰的記憶？？";
                }
                else if (count == 4)
                {
                    dialog.text = "";
                    move = true;
                    GameDataManager.move = move;
                    drama_played = false;
                    GameDataManager.backfromalbum = false;
                    GameDataManager.drama_played = drama_played;
                    Debug.Log("開始人物移動");
                    this.dialog_box.SetActive(false);
                }
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
