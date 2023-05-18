using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSwitch : MonoBehaviour
{   
    public Animation Anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {   
        if(GameDataManager.state==4){
            StartCoroutine(ToEndScene());
        }
    }
    IEnumerator ToEndScene(){
        Anim.Play("SwitchFadeOut");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("End");
    }
}
