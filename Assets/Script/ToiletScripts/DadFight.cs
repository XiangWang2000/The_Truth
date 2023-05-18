using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DadFight : MonoBehaviour
{
    public GameObject trig;
    public Animation Anim;
    public GameObject Player;
    bool touched = false;
    float timer_f = 0f;
    int timer_i = 0;
    int timer_i_f = 0;
    private bool Rope;
    private int state;
    // Start is called before the first frame update
    void Start()
    {
        this.trig.SetActive(false);
        Rope = GameDataManager.Rope;
        state = GameDataManager.state;
        if (state > 1)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Anim.Play("SwitchFadeOut");
        }
        timer_f += Time.deltaTime;
        timer_i = (int)timer_f;
        // Debug.Log(timer_i);
        if (touched)
        {
            trig.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 3.5f, trig.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.F) && touched == true)
        {
            Debug.Log("輸入F了");
            this.trig.SetActive(false);
            // Debug.Log("全域變數Rope值" + GameDataManager.Rope);
            if (Rope == false)
            {
                Debug.Log("道具不夠");
                StartCoroutine(ToItemDead());
                Anim.Play("SwitchFadeOut");
                touched = false;
            }
            else
            {
                StartCoroutine(ToFight());
                Debug.Log("進入戰鬥");
                Anim.Play("SwitchFadeOut");
                touched = false;
            }
        }
        else if (touched == true)
        {
            if (timer_i - timer_i_f == 2)
            {
                Debug.Log("沒輸F");
                this.trig.SetActive(false);
                StartCoroutine(ToDead());
                Anim.Play("SwitchFadeOut");
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            timer_i_f = timer_i;
            this.trig.SetActive(true);
            touched = true;
            Debug.Log("碰到鬼了");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        this.trig.SetActive(false);
        touched = false;
    }
    IEnumerator ToFight()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("DadFightScene");
    }
    IEnumerator ToDead()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("DeadScene");
    }
    IEnumerator ToItemDead()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("UnenoughItem");
    }
}
