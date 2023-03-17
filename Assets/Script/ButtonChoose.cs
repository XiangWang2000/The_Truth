using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChoose : MonoBehaviour
{   
    public GameObject StartConfirm;
    public GameObject ResumeConfirm;
    public GameObject ExitConfirm;
    GameObject [] ConfirmArray  = new GameObject [3];
    int count = 0 ; 
    // Start is called before the first frame update
    void Start()
    {   
        ConfirmArray[0] = StartConfirm;
        ConfirmArray[1] = ResumeConfirm;
        ConfirmArray[2] = ExitConfirm;
        StartConfirm.SetActive(true);
        ResumeConfirm.SetActive(false);
        ExitConfirm.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            if(count != 2){
                count+=1;
                ShowConfirm(count-1,count);
            }
        }
         if(Input.GetKeyDown(KeyCode.UpArrow)){
            if(count != 0){
                count-=1;
                ShowConfirm(count+1,count);
            }
        }
        Debug.Log(count);
    }
    void ShowConfirm(int No1,int No2){
        ConfirmArray[No1].SetActive(false);
        ConfirmArray[No2].SetActive(true);
    }
}
