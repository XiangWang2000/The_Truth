using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BrotherRoomSwitch : MonoBehaviour
{   
    public GameObject trig;
    bool touched = false;
    private bool move;
    private float posx;
    private bool brother_room_entered;
    public GameObject player;
    public AudioSource intotheroom;
    private bool isinGranadmaPart;
    public Animation Anim;
    public GameObject Warn;
    public GameObject camera;
    public Animator WarnAnimator;
    // Start is called before the first frame update
    void Start()
    {   
        this.trig.SetActive(false);
        this.isinGranadmaPart = GameDataManager.isinGranadmaPart;
        posx = GameDataManager.posx;
        brother_room_entered = GameDataManager.brother_room_entered;
    }
    // Update is called once per frame
    void Update()
    {
        move = GameDataManager.move;
        if ((Input.GetKeyDown(KeyCode.UpArrow) | Input.GetKeyDown("w")) && touched == true && move == true && !isinGranadmaPart)
        {   
            Debug.Log("進入弟弟房間");
            posx = player.transform.position.x;
            brother_room_entered = true;
            GameDataManager.posx = posx;
            GameDataManager.brother_room_entered = brother_room_entered;
            this.trig.SetActive(false);
            StartCoroutine(EnterBrotherRoom());
        }else if ((Input.GetKeyDown(KeyCode.UpArrow) | Input.GetKeyDown("w")) && touched == true && move == true && isinGranadmaPart){
            Debug.Log("相機X:"+camera.transform.position.x);
            Debug.Log("相機Y:"+camera.transform.position.y);
            Debug.Log("相機Z:"+camera.transform.position.z);
            Warn.transform.position = new Vector3(camera.transform.position.x+12,camera.transform.position.y+5.5f,camera.transform.position.z+11);
            WarnAnimator.SetBool("isWarn",true);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(isinGranadmaPart){
            this.trig.SetActive(true);
            Debug.Log("碰到弟弟房間門了，但是奶奶在追你，所以你逃不掉哈哈");
            touched = true;
        }else{
            this.trig.SetActive(true);
            Debug.Log("碰到弟弟房間門了");
            touched = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        this.trig.SetActive(false);
        touched = false;
    }
    IEnumerator EnterBrotherRoom(){
        intotheroom.Play(0);
        Anim.Play("SwitchFadeOut");
        yield return new WaitForSeconds(4);
        SceneManager.LoadScene("BrotherRoom");
    }
}
