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
    public static int count = 0;

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
            Debug.Log(count);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ButtonAudio.Play(0);
            if (count != 0)
            {
                count -= 1;
                ShowConfirm(count + 1, count);
            }
            Debug.Log(count);
        }
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            ButtonAudio.Play(0);
            if (count == 0)
            {
                resetdata();
                Anim.Play("O0");
                // GameDataManager.state = 1;
            }
            else if (count == 1)
            {
                if (PlayerPrefs.HasKey("state"))
                {
                    Debug.Log("有紀錄");
                    Anim.Play("ToCurrent");
                    dataload();
                    SceneManager.LoadScene(GameDataManager.SceneName);
                }
                else
                {
                    Debug.Log("未有紀錄");
                }
            }
            else
            {
                Application.Quit();
                // EditorApplication.isPlaying="false";
            }
        }
    }
    void resetdata()
    {
        GameDataManager.state = 1; // 第幾關
        GameDataManager.Rope = false;
        GameDataManager.Album = false;
        GameDataManager.Pot = false;
        GameDataManager.Blood_Tissue = false;
        GameDataManager.Invoice = false;
        GameDataManager.Tissue = false;
        GameDataManager.Draw = false;
        GameDataManager.Key = false;
        GameDataManager.Note = false;
        GameDataManager.move = true;
        GameDataManager.dead = 0;
        GameDataManager.dad_dead = false;
        GameDataManager.posx = 0f;
        GameDataManager.toilet_entered = false;
        GameDataManager.second_floor_entered = false;
        GameDataManager.brother_room_entered = false;
        GameDataManager.parent_room_entered = false;
        GameDataManager.grandmom_room_entered = false;
        GameDataManager.drama_played = false;
        GameDataManager.window_count = 1;
        GameDataManager.MirrorBlood = false;
        GameDataManager.isinGranadmaPart = false;
        GameDataManager.GrandMaCanDie = false;
        GameDataManager.FirstTimeGetinGrandMaRoom = true;
        GameDataManager.isFirstToSecond = true;
        GameDataManager.SceneName = "FirstScene";
    }
    void dataload()
    {
        GameDataManager.state = PlayerPrefs.GetInt("state");
        GameDataManager.Rope = convert(PlayerPrefs.GetInt("Rope"));
        GameDataManager.Album = convert(PlayerPrefs.GetInt("Album"));
        GameDataManager.Pot = convert(PlayerPrefs.GetInt("Pot"));
        GameDataManager.Blood_Tissue = convert(PlayerPrefs.GetInt("Blood_Tissue"));
        GameDataManager.Invoice = convert(PlayerPrefs.GetInt("Invoice"));
        GameDataManager.Tissue = convert(PlayerPrefs.GetInt("Tissue"));
        GameDataManager.Draw = convert(PlayerPrefs.GetInt("Draw"));
        GameDataManager.Key = convert(PlayerPrefs.GetInt("Key"));
        GameDataManager.Note = convert(PlayerPrefs.GetInt("Note"));
        GameDataManager.move = convert(PlayerPrefs.GetInt("move"));
        GameDataManager.dad_dead = convert(PlayerPrefs.GetInt("dad_dead"));
        GameDataManager.posx = PlayerPrefs.GetFloat("posx");
        GameDataManager.toilet_entered = convert(PlayerPrefs.GetInt("toilet_entered"));
        GameDataManager.second_floor_entered = convert(PlayerPrefs.GetInt("second_floor_entered"));
        GameDataManager.brother_room_entered = convert(PlayerPrefs.GetInt("brother_room_entered"));
        GameDataManager.parent_room_entered = convert(PlayerPrefs.GetInt("parent_room_entered"));
        GameDataManager.grandmom_room_entered = convert(PlayerPrefs.GetInt("grandmom_room_entered"));
        GameDataManager.drama_played = convert(PlayerPrefs.GetInt("drama_played"));
        GameDataManager.window_count = PlayerPrefs.GetInt("window_count");
        GameDataManager.MirrorBlood = convert(PlayerPrefs.GetInt("MirrorBlood"));
        GameDataManager.isinGranadmaPart = convert(PlayerPrefs.GetInt("isinGranadmaPart"));
        GameDataManager.GrandMaCanDie = convert(PlayerPrefs.GetInt("GrandMaCanDie"));
        GameDataManager.FirstTimeGetinGrandMaRoom = convert(PlayerPrefs.GetInt("FirstTimeGetinGrandMaRoom"));
        GameDataManager.SceneName = PlayerPrefs.GetString("SceneName");
        PlayerPrefs.DeleteAll();
    }
    bool convert(int tf)
    {
        return tf == 1;
    }
    void ShowConfirm(int No1, int No2)
    {
        ConfirmArray[No1].SetActive(false);
        ConfirmArray[No2].SetActive(true);
    }
}
