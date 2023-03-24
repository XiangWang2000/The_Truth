using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstStageSwitch : MonoBehaviour
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
            this.trig.SetActive(false);
            Debug.Log("進入一樓場景");
            SceneManager.LoadScene("FirstScene");
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
