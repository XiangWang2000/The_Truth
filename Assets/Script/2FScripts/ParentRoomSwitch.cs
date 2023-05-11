using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParentRoomSwitch : MonoBehaviour
{
    public GameObject trig;
    bool touched = false;
    private bool move;
    private float posx;
    private bool parent_room_entered;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        this.trig.SetActive(false);
        posx = GameDataManager.posx;
        parent_room_entered = GameDataManager.parent_room_entered;
    }


    // Update is called once per frame
    void Update()
    {
        move = GameDataManager.move;
        if ((Input.GetKeyDown(KeyCode.UpArrow) | Input.GetKeyDown("w")) && touched && move)
        {
            Debug.Log("進入父母房間");
            posx = player.transform.position.x;
            parent_room_entered = true;
            GameDataManager.posx = posx;
            GameDataManager.parent_room_entered = parent_room_entered;
            this.trig.SetActive(false);
            SceneManager.LoadScene("ParentRoom");
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