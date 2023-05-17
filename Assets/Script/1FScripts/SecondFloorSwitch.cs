using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondFloorSwitch : MonoBehaviour
{
    public GameObject trig;
    public GameObject player;
    bool touched = false;
    private float posx;
    private bool second_floor_entered;
    private bool move;
    private bool dad_dead;
    public Animation Anim;
    public AudioSource Audio;
    // Start is called before the first frame update
    void Start()
    {   
        this.trig.SetActive(false);
        posx = GameDataManager.posx;
        dad_dead = GameDataManager.dad_dead;
    }

    // Update is called once per frame
    void Update()
    {
        move = GameDataManager.move;
        if ((Input.GetKeyDown(KeyCode.UpArrow) | Input.GetKeyDown("w")) && touched && move && dad_dead)
        {
            this.trig.SetActive(false);
            Debug.Log("進入二樓場景");
            posx = player.transform.position.x;
            GameDataManager.posx = posx;
            second_floor_entered = true;
            GameDataManager.second_floor_entered = second_floor_entered;
            if(GameDataManager.isFirstToSecond){
                Debug.Log("第一次上二樓");
                GameDataManager.isFirstToSecond = false;
                StartCoroutine(FirstToSecond());
            }else{
                SceneManager.LoadScene("SecondScene");
            }
            
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
        Audio.Play(0);
        Anim.Play("SwitchFadeOut");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("SecondScene");
    }
}
