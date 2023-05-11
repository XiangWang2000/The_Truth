using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondFloorFromSeondSwitch : MonoBehaviour
{
    private GameObject enter_hint;
    bool touched = false;
    private bool move;

    public int RoomCode = 1;//1為弟弟房間,2為父母房間,3為奶奶房間
    // Start is called before the first frame update
    void Start()
    {
        enter_hint = GameObject.FindGameObjectWithTag("Enter_Hint");
        enter_hint.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        move = GameDataManager.move;
        if ((Input.GetKeyDown(KeyCode.UpArrow) | Input.GetKeyDown("w")) && touched && move)
        {
            enter_hint.SetActive(false);
            Debug.Log("進入二樓場景");
            SceneManager.LoadScene("SecondScene");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        enter_hint.SetActive(true);
        Debug.Log("碰到門了");
        touched = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        enter_hint.SetActive(false);
        touched = false;
    }
}
