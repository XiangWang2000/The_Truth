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
            intotheroom.Play(0);
            Debug.Log("進入弟弟房間");
            posx = player.transform.position.x;
            brother_room_entered = true;
            GameDataManager.posx = posx;
            GameDataManager.brother_room_entered = brother_room_entered;
            this.trig.SetActive(false);
            SceneManager.LoadScene("BrotherRoom");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(isinGranadmaPart){
            this.trig.SetActive(false);
            Debug.Log("碰到弟弟房間門了，但是奶奶在追你，所以你逃不掉哈哈");
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
}
