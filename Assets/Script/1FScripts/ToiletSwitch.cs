using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToiletSwitch : MonoBehaviour
{
    public GameObject trig;
    public GameObject player;
    bool touched = false;
    private float posx;
    private bool toilet_entered;
    // Start is called before the first frame update
    void Start()
    {
        this.trig.SetActive(false);
        posx = GameDataManager.posx;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) | Input.GetKeyDown("w") && touched == true)
        {
            this.trig.SetActive(false);
            Debug.Log("進入廁所場景");
            posx = player.transform.position.x;
            GameDataManager.posx = posx;
            toilet_entered = true;
            GameDataManager.toilet_entered = toilet_entered;
            SceneManager.LoadScene("ToiletScene");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        this.trig.SetActive(true);
        Debug.Log("碰到廁所門了");
        touched = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        this.trig.SetActive(false);
        touched = false;
    }
}
