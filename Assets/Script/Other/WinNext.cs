using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinNext : MonoBehaviour
{   
    private Animation Anim;
    
    // Start is called before the first frame update
    void Start()
    {   
        Anim = GetComponent<Animation>();
        if(GameDataManager.state == 2){
            StartCoroutine(AfterDadDead());
        }else if (GameDataManager.state == 3){
             StartCoroutine(AfterBrotherDead());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    void LoadMap(string scene){
        SceneManager.LoadScene(scene);
    }
    IEnumerator AfterDadDead(){
        yield return new WaitForSeconds(3);
        Anim.Play("AfterDadDead");
    }
    IEnumerator AfterBrotherDead(){
        yield return new WaitForSeconds(3);
        Anim.Play("AfterBrotherDead");
    }
}
