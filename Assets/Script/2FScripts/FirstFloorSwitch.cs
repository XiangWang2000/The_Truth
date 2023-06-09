using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstFloorSwitch : MonoBehaviour
{
    public GameObject trig;
    bool touched = false;
    private bool move;
    private bool isinGranadmaPart;
    public Animation Anim;
    public GameObject Warn;
    public GameObject camera;
    public Animator WarnAnimator;
    // Start is called before the first frame update
    void Start()
    {
        this.trig.SetActive(false);
        this.isinGranadmaPart = GameDataManager.isinGranadmaPart;
    }

    // Update is called once per frame
    void Update()
    {
        move = GameDataManager.move;
        if ((Input.GetKeyDown(KeyCode.UpArrow) | Input.GetKeyDown("w")) && touched == true && move == true && !isinGranadmaPart)
        {
            Debug.Log("進入一樓場景");
            this.trig.SetActive(false);
            Anim.Play("SwitchFadeOut");
            SceneManager.LoadScene("FirstScene");
        }else if ((Input.GetKeyDown(KeyCode.UpArrow) | Input.GetKeyDown("w")) && touched == true && move == true && isinGranadmaPart){
            Debug.Log("相機X:"+camera.transform.position.x);
            Debug.Log("相機Y:"+camera.transform.position.y);
            Debug.Log("相機Z:"+camera.transform.position.z);
            Warn.transform.position = new Vector3(camera.transform.position.x+12,camera.transform.position.y+5.5f,camera.transform.position.z+11);
            WarnAnimator.SetBool("isWarn",true);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {   
        if(isinGranadmaPart){
            this.trig.SetActive(true);
            Debug.Log("碰到階梯了，但是奶奶在追你，所以你逃不掉哈哈");
            touched = true;
        }else{
            this.trig.SetActive(true);
            Debug.Log("碰到階梯了");
            touched = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        this.trig.SetActive(false);
        touched = false;
    }
}
