using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToiletSwitch : MonoBehaviour
{
    public GameObject trig;
    bool touched=false;
    // Start is called before the first frame update
    void Start()
    {
        this.trig.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow) | Input.GetKey("w") && touched==true){
            this.trig.SetActive(false);
            Debug.Log("進入廁所場景");
            SceneManager.LoadScene("ToiletScene");
        }
    }
    void OnTriggerEnter2D(Collider2D other) {
        this.trig.SetActive(true);
        Debug.Log("碰到廁所門了");
        touched=true;
    }
    private void OnTriggerExit2D(Collider2D other) {
        this.trig.SetActive(false);
        touched=false;
    }
}
