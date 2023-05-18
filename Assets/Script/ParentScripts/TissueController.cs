using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TissueController : MonoBehaviour
{   
    private bool touched = false;
    private bool move;
    private bool read = false;
    private GameObject trig;
    private GameObject Player;
    private GameObject dialog_box;
    private Text dialog;
    private GameObject camera_position;
    private Image center_image;
    public AudioSource audio;
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
        if(GameDataManager.Tissue){
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
            audio.Play(0);
            center_image.color = new Color(1f, 1f, 1f, 1f);
            center_image.rectTransform.sizeDelta = new Vector2(300f, 300f);
            this.trig.SetActive(false);
            touched = false;
            move = false;
            GameDataManager.move = move;
            Debug.Log("停止人物移動");
            Debug.Log("開始對話");
            dialog_box.transform.position = new Vector3(camera_position.transform.position.x, camera_position.transform.position.y - 3, dialog_box.transform.position.z);
            dialog.text = "什⋯什麼聲音？";
            dialog_box.SetActive(true);
            center_image.sprite = Resources.Load<Sprite>("Bag/衛生紙");
            GameDataManager.Tissue = true;
            read = true;
        }
        if (read)
        {
            if (Input.GetKeyDown("space"))
            {   
                audio.Pause();
                dialog.text = "";
                GameDataManager.move = true;
                Debug.Log("開始人物移動");
                center_image.color = new Color(1f, 1f, 1f, 0f);
                dialog_box.SetActive(false);
                this.gameObject.SetActive(false);
                read = false;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && !GameDataManager.Tissue)
        {
            touched = true;
            trig.SetActive(true);
            Debug.Log("碰到舒潔");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        touched = false;
        trig.SetActive(false);
    }
}
