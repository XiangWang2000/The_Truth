using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchIntroduce : MonoBehaviour
{   
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    public GameObject Image4;
    public GameObject Image5;
    public GameObject Image6;
    public GameObject Image7;
    public GameObject Image8;
    public GameObject [] ImageArray = new GameObject[8] ;

    int count = 0;
    // float speed = 0.1 ;
    // float ColorAlpha = 0.9f;
    // float temp = 0;
    // Start is called before the first frame update
    void Start()
    {  
        ImageArray[0] = Image1;
        ImageArray[1] = Image2;
        ImageArray[2] = Image3;
        ImageArray[3] = Image4;
        ImageArray[4] = Image5;
        ImageArray[5] = Image6;
        ImageArray[6] = Image7;
        ImageArray[7] = Image8;
        ImageArray[0].SetActive(true);
        for(int i=1;i<8;i++){
            ImageArray[i].SetActive(false);
        }//初始設定
    }

    // Update is called once per frame
    void Update()
    {   
        while(count<=7){
            if(Input.GetKeyDown(KeyCode.Space)){
                count+=1;
            }
            ImageArray[count].SetActive(false);
            ImageArray[count].SetActive(true);
        }

    }
}
