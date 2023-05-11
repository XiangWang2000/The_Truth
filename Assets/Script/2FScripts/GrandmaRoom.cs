using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrandmaRoom : MonoBehaviour
{
    public GameObject trig;
    bool touched = false;
    private bool move;
    private float posx;
    private bool grandmom_room_entered;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        this.trig.SetActive(false);
        posx = GameDataManager.posx;
        grandmom_room_entered = GameDataManager.grandmom_room_entered;
    }


    // Update is called once per frame
    void Update()
    {
        move = GameDataManager.move;
        if ((Input.GetKeyDown(KeyCode.UpArrow) | Input.GetKeyDown("w")) && touched == true && move == true)
        {
            Debug.Log("進入弟弟房間");
            posx = player.transform.position.x;
            grandmom_room_entered = true;
            GameDataManager.posx = posx;
            GameDataManager.grandmom_room_entered = grandmom_room_entered;
            this.trig.SetActive(false);
            SceneManager.LoadScene("GrandMaRoom");
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
