using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TrashCanController : MonoBehaviour
{
    private bool touched = false;
    private bool move;
    private bool read = false;
    private float Broposx;
    private GameObject trig;
    private GameObject Player;
    private GameObject dialog_box;
    private Text dialog;
    private GameObject camera_position;
    private Image center_image;
    // Start is called before the first frame update
    void Start()
    {
        move = GameDataManager.move;
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
            center_image.color = new Color(1f, 1f, 1f, 1f);
            center_image.rectTransform.sizeDelta = new Vector2(300f, 300f);
            this.trig.SetActive(false);
            touched = false;
            move = false;
            GameDataManager.move = move;
            Debug.Log("停止人物移動");
            Debug.Log("開始對話");
            dialog_box.transform.position = new Vector3(camera_position.transform.position.x, camera_position.transform.position.y - 3, dialog_box.transform.position.z);
            dialog.text = "這裡面衛生紙怎麼那麼多血";
            center_image.sprite = Resources.Load<Sprite>("BrotherRoomImage/染血衛生紙");
            GameDataManager.Blood_Tissue = true;
            read = true;
        }
        if (read)
        {
            if (Input.GetKeyDown("space"))
            {
                dialog.text = "";
                GameDataManager.move = true;
                Debug.Log("開始人物移動");
                center_image.color = new Color(1f, 1f, 1f, 0f);
                dialog_box.SetActive(false);
                read = false;
                Broposx = Player.transform.position.x;
                GameDataManager.Broposx = Broposx;
                GameDataManager.Bloody_Tissue_drama_played = true;
                SceneManager.LoadScene("Bloody_Tissue");
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !GameDataManager.Blood_Tissue)
        {
            touched = true;
            trig.SetActive(true);
            Debug.Log("碰到垃圾桶");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        touched = false;
        trig.SetActive(false);
    }
}
