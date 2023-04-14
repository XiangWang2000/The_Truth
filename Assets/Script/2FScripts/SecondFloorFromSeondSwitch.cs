using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondFloorFromSeondSwitch : MonoBehaviour
{   
    public GameObject trig;
    public GameObject player;
    bool touched = false;
    private float posx;
    private bool second_floor_entered;
    private bool move;

    public int RoomCode =  1;//1為弟弟房間,2為父母房間,3為奶奶房間
    // Start is called before the first frame update
    void Start()
    {
        this.trig.SetActive(false);
        posx = GameDataManager.posx;
    }

    // Update is called once per frame
    void Update()
    {
        move = GameDataManager.move;
        if ((Input.GetKeyDown(KeyCode.UpArrow) | Input.GetKeyDown("w")) && touched && move)
        {
            this.trig.SetActive(false);
            Debug.Log("進入二樓場景");
            // posx = player.transform.position.x;
            // GameDataManager.posx = posx;
            second_floor_entered = true;
            GameDataManager.second_floor_entered = second_floor_entered;
            SceneManager.LoadScene("SecondScene");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {   
            this.trig.SetActive(true);
            Debug.Log("碰到門了");
            touched = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        this.trig.SetActive(false);
        touched = false;
    }
}
