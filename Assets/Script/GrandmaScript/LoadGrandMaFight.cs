using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGrandMaFight : MonoBehaviour
{   
    public GameObject Btn1;
    public GameObject Btn2;
    public GameObject Btn3;
    public GameObject BtnCheck1;
    public GameObject BtnCheck2;
    public GameObject BtnCheck3;
    private int[] BtnArray = { 1, 0, 0 };
    private GameObject[] BtnCheckArray = new GameObject[3];
    private AudioSource AudioSource;
    private int answer = 0;
    private Scene scene ;
    // Start is called before the first frame update
    void Start()
    {   
        scene = SceneManager.GetActiveScene ();
        AudioSource = GetComponent<AudioSource>();
        BtnCheck1.SetActive(true);
        BtnCheck2.SetActive(false);
        BtnCheck3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.DownArrow)|Input.GetKeyDown("s"))
        {
            AudioSource.Play(0);
            if(BtnArray[0]==1){
                BtnCheck1.SetActive(false);
                BtnCheck2.SetActive(true);
                BtnCheck3.SetActive(false);
                BtnArray[0]=0;
                BtnArray[1]=1;
                BtnArray[2]=0;
                answer = 1;
            }else if (BtnArray[1]==1){
                BtnCheck1.SetActive(false);
                BtnCheck2.SetActive(false);
                BtnCheck3.SetActive(true);
                BtnArray[0]=0;
                BtnArray[1]=0;
                BtnArray[2]=1;
                answer = 2;
            }else{
                BtnCheck1.SetActive(true);
                BtnCheck2.SetActive(false);
                BtnCheck3.SetActive(false);
                BtnArray[0]=1;
                BtnArray[1]=0;
                BtnArray[2]=0;
                answer = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)|Input.GetKeyDown("w"))
        {
            AudioSource.Play(0);
            if(BtnArray[0]==1){
                BtnCheck1.SetActive(false);
                BtnCheck2.SetActive(false);
                BtnCheck3.SetActive(true);
                BtnArray[0]=0;
                BtnArray[1]=0;
                BtnArray[2]=1;
                answer = 2;
            }else if (BtnArray[1]==1){
                BtnCheck1.SetActive(true);
                BtnCheck2.SetActive(false);
                BtnCheck3.SetActive(false);
                BtnArray[0]=1;
                BtnArray[1]=0;
                BtnArray[2]=0;
                answer = 0;
            }else{
                BtnCheck1.SetActive(false);
                BtnCheck2.SetActive(true);
                BtnCheck3.SetActive(false);
                BtnArray[0]=0;
                BtnArray[1]=1;
                BtnArray[2]=0;
                answer = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (answer == 2){
                Debug.Log(scene.name);
                if(!GameDataManager.GrandMaCanDie){
                    Debug.Log("答錯了");
                    SceneManager.LoadScene("NoStair");
                }else{
                    Debug.Log("答對了");
                    GameDataManager.isinGranadmaPart = false;
                    GameDataManager.state = 4;
                    SceneManager.LoadScene("GM_Death");
                }
                
            }else if (answer==0){
                Debug.Log("答錯了");
                SceneManager.LoadScene("Appease");
            }else{
                Debug.Log("答錯了");
                SceneManager.LoadScene("PotUsed");
            }
        }
    }
}
