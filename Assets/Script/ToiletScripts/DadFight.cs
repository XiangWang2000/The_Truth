using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DadFight : MonoBehaviour
{   
    public GameObject trig;
    public Animation Anim;

    bool touched=false;
    float timer_f = 0f;
    int timer_i = 0;
    int timer_i_f = 0;


    // Start is called before the first frame update
    void Start()
    {
        this.trig.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.I)){
            Anim.Play("SwitchFadeOut");
        }
        timer_f+=Time.deltaTime;
        timer_i = (int)timer_f;
        Debug.Log(timer_i);
        if(Input.GetKey(KeyCode.F) && touched==true){
            Debug.Log("輸入F了");
            this.trig.SetActive(false);
            StartCoroutine(ToFight());
            Anim.Play("SwitchFadeOut");
            touched = false;
        }else if (touched==true){
            if(timer_i-timer_i_f==2){
                Debug.Log("沒輸F");
                this.trig.SetActive(false);
                StartCoroutine(ToDead());
                Anim.Play("Dead");
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player"){
            timer_i_f = timer_i;
            this.trig.SetActive(true);
            touched=true;
            Debug.Log("碰到鬼了");
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        this.trig.SetActive(false);
        touched=false;
    }
    IEnumerator ToFight(){
        yield return  new WaitForSeconds(2);
        Application.LoadLevel("DadFightScene");
    }
    IEnumerator ToDead(){
        yield return  new WaitForSeconds(2);
        Application.LoadLevel("FirstScene");
    }
}
