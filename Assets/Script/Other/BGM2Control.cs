using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM2Control : MonoBehaviour
{   
    public GameObject TitleBGM;
    GameObject BGM = null;
    // static BGM2Control _instance;
    // // Start is called before the first frame update
    // public static BGM2Control instance{
    //     get {
    //         if (_instance == null){
    //             _instance = FindObjectOfType<BGM2Control>();
    //             DontDestroyOnLoad(_instance.gameObject);
    //         }
    //         return _instance;
    //     }
    // }
    // void Awake(){
    //     if(_instance == null){
    //         _instance = this;
    //         DontDestroyOnLoad(this);
    //     }else if (this != _instance){
    //         Destroy(gameObject);
    //     }
    // }
    void Start()
    {
        BGM = GameObject.FindGameObjectWithTag("Sound");
        SceneManager.MoveGameObjectToScene(BGM, SceneManager.GetActiveScene());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
