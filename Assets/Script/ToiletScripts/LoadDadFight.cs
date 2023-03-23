using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDadFight : MonoBehaviour
{      
    public GameObject Btn1;
    public GameObject Btn2;
    public GameObject Btn3;
    public GameObject BtnCheck1;
    public GameObject BtnCheck2;
    public GameObject BtnCheck3;
    private int [] BtnArray = {1,0,0};
    private GameObject [] BtnCheckArray = new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {   
        int[] X = new int[3];    
        int[] Y = new int[3];
            for (int i = 0; i < 3; i++)    
            {
                X[i] = Random.Range(-529,248);
                Y[i] = Random.Range(-355, 356);   

                for (int j = 0; j < i; j++) 
                {
                    while (X[j] - X[i] <= 200)    
                    {
                        j = 0;  
                        X[i] = Random.Range(-529,248);  
                    }
                    while (Y[j] - Y[i] <= 70)   
                    {
                        j = 0; 
                        Y[i] = Random.Range(-355, 356);   
                    }
                }
            }
        int X1 = X[0];
        int X2 = X[1];
        int X3 = X[2];
        int Y1 = Y[0];
        int Y2 = Y[1];
        int Y3 = Y[2];
        Btn1.transform.localPosition = new Vector3(X1,Y1,Btn1.transform.localPosition.z);
        Btn2.transform.localPosition = new Vector3(X2,Y2,Btn1.transform.localPosition.z);
        Btn3.transform.localPosition = new Vector3(X3,Y3,Btn1.transform.localPosition.z);
        BtnCheck1.SetActive(true);
        BtnCheck2.SetActive(false);
        BtnCheck3.SetActive(false);
        if(Y1>=Y2&&Y1>=Y3&&Y2>=Y3){
            BtnCheckArray[0] = BtnCheck1;
            BtnCheckArray[1] = BtnCheck2;
            BtnCheckArray[2] = BtnCheck3;
        }else if (Y1>=Y2&&Y1>=Y3&&Y3>=Y2){
            BtnCheckArray[0] = BtnCheck1;
            BtnCheckArray[1] = BtnCheck3;
            BtnCheckArray[2] = BtnCheck2;
        }else if(Y2>=Y1&&Y2>=Y3&&Y1>=Y3){
            BtnCheckArray[0] = BtnCheck2;
            BtnCheckArray[1] = BtnCheck1;
            BtnCheckArray[2] = BtnCheck3;
        }else if (Y2>=Y1&&Y2>=Y3&&Y3>=Y1){
            BtnCheckArray[0] = BtnCheck2;
            BtnCheckArray[1] = BtnCheck3;
            BtnCheckArray[2] = BtnCheck1;
        }else if(Y3>=Y2&&Y3>=Y1&&Y2>=Y1){
            BtnCheckArray[0] = BtnCheck3;
            BtnCheckArray[1] = BtnCheck2;
            BtnCheckArray[2] = BtnCheck1;
        }else if (Y3>=Y2&&Y3>=Y1&&Y1>=Y2){
            BtnCheckArray[0] = BtnCheck3;
            BtnCheckArray[1] = BtnCheck1 ;
            BtnCheckArray[2] = BtnCheck2;
        } 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            if(BtnArray[0]==1){
                BtnArray[2]=0;
                BtnArray[0]=0;
                BtnArray[1]=1;
                BtnCheckArray[0].SetActive(false);
                BtnCheckArray[1].SetActive(true);
            }else if (BtnArray[1]==1){
                BtnArray[0]=0;
                BtnArray[1]=0;
                BtnArray[2]=1;
                BtnCheckArray[1].SetActive(false);
                BtnCheckArray[2].SetActive(true);
            }else{
                BtnArray[1]=0;
                BtnArray[2]=0;
                BtnArray[0]=1;
                BtnCheckArray[2].SetActive(false);
                BtnCheckArray[0].SetActive(true);
            }
        }
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            if(BtnArray[0]==1){
                BtnArray[1]=0;
                BtnArray[0]=0;
                BtnArray[2]=1;
                BtnCheck1.SetActive(false);
                BtnCheck3.SetActive(true);
            }else if (BtnArray[1]==1){
                BtnArray[2]=0;
                BtnArray[1]=0;
                BtnArray[0]=1;
                BtnCheck2.SetActive(false);
                BtnCheck1.SetActive(true);
            }else{
                BtnArray[0]=0;
                BtnArray[2]=0;
                BtnArray[1]=1;
                BtnCheck3.SetActive(false);
                BtnCheck2.SetActive(true);
            }
        }
    }
}
