using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SecondFloorSwitch : MonoBehaviour
{
    public GameObject trig;
    public GameObject player;
    public GameObject dialog_box;
    public GameObject camera_position;
    public Text dialog;
    private bool touched = false;
    private bool move;
    private float Exposx;
    private bool second_floor_entered;
    private bool dad_dead;
    public Animation Anim;
    public AudioSource Audio;
    public bool communicate = false;
    // Start is called before the first frame update
    void Start()
    {   
        this.trig.SetActive(false);
        Exposx = GameDataManager.Exposx;
        dad_dead = GameDataManager.dad_dead;
        this.dialog_box.SetActive(false);
        move = GameDataManager.move;
    }

    // Update is called once per frame
    void Update()
    {
        move = GameDataManager.move;
        if ((Input.GetKeyDown(KeyCode.UpArrow) | Input.GetKeyDown("w")) && touched && move && dad_dead)
        {
            this.trig.SetActive(false);
            Debug.Log("進入二樓場景");
            Exposx = player.transform.position.x;
            GameDataManager.Exposx = Exposx;
            second_floor_entered = true;
            GameDataManager.second_floor_entered = second_floor_entered;
            if(GameDataManager.isFirstToSecond){
                Audio.Play(0);
                StartCoroutine(WaitForMusic());
            }else{
                SceneManager.LoadScene("SecondScene");
            }
        }
        if((Input.GetKeyDown("space"))&&communicate){
                dialog.text = "";
                move = true;
                GameDataManager.move = true;
                Debug.Log("開始人物移動");
                this.dialog_box.SetActive(false);
                Debug.Log("第一次上二樓");
                GameDataManager.isFirstToSecond = false;
                StartCoroutine(FirstToSecond());  
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (dad_dead)
        {
            this.trig.SetActive(true);
            Debug.Log("碰到階梯了");
            touched = true;
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        this.trig.SetActive(false);
        touched = false;
    }
    IEnumerator FirstToSecond(){
        Anim.Play("SwitchFadeOut");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("SecondScene");
    }
    IEnumerator WaitForMusic(){
        yield return new WaitForSeconds(2);
        communicate = true;
        this.dialog_box.SetActive(true);
        this.dialog_box.transform.position = new Vector3(camera_position.transform.position.x, camera_position.transform.position.y - 3, dialog_box.transform.position.z);
        touched = false;
        move = false;
        GameDataManager.move = move;
        Debug.Log("停止人物移動");
        Debug.Log("開始對話");
        dialog.text = "剛剛是什麼聲音？";
    }
}
