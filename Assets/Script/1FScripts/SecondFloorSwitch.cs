using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondFloorSwitch : MonoBehaviour
{
    public GameObject trig;
    bool touched = false;
    private bool move;
    // Start is called before the first frame update
    void Start()
    {
        this.trig.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        move = GameDataManager.move;
        if ((Input.GetKeyDown(KeyCode.UpArrow) | Input.GetKeyDown("w")) && touched == true && move == true)
        {
            Debug.Log("進入二樓場景");
            this.trig.SetActive(false);
            SceneManager.LoadScene("SecondScene");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        this.trig.SetActive(true);
        Debug.Log("碰到階梯了");
        touched = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        this.trig.SetActive(false);
        touched = false;
    }
}
