using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonChoose : MonoBehaviour
{
    public GameObject StartConfirm;
    public GameObject ResumeConfirm;
    public GameObject ExitConfirm;
    [SerializeField] private AudioSource ButtonAudio;
    GameObject[] ConfirmArray = new GameObject[3];
    int count = 0;

    public Animation Anim;
    // Start is called before the first frame update

    private int state = 1;
    void Start()
    {
        ButtonAudio = GetComponent<AudioSource>();
        ConfirmArray[0] = StartConfirm;
        ConfirmArray[1] = ResumeConfirm;
        ConfirmArray[2] = ExitConfirm;
        StartConfirm.SetActive(true);
        ResumeConfirm.SetActive(false);
        ExitConfirm.SetActive(false);
        state = GameDataManager.state;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ButtonAudio.Play(0);
            if (count != 2)
            {
                count += 1;
                ShowConfirm(count - 1, count);
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ButtonAudio.Play(0);
            if (count != 0)
            {
                count -= 1;
                ShowConfirm(count + 1, count);
            }
        }
        Debug.Log(count);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ButtonAudio.Play(0);
            if (count == 0)
            {
                Anim.Play("O0");
                // GameDataManager.state = 1;
            }
            else if (count == 1)
            {
                Anim.Play("ToCurrent");
            }
            else
            {
                Application.Quit();
                // EditorApplication.isPlaying="false";
            }
        }

    }
    void ShowConfirm(int No1, int No2)
    {
        ConfirmArray[No1].SetActive(false);
        ConfirmArray[No2].SetActive(true);
    }
    void LoadMap()
    {   
        // String NextScene = "Intro1";
        // if(state == 1){
        //     NextScene = "FirstScene";
        //     Debug.Log("開始遊戲");
        // }else if(state == 2){
        //     NextScene = "SecondScene";
        //     Debug.Log("進入已經進行的遊戲");
        // }else{
        //     NextScene = "";
        // }
        switch (count)
        {
            case 0: SceneManager.LoadScene("Intro1"); break;
            case 1: SceneManager.LoadScene("FirstScene"); break;
        }
    }
}
