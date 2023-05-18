using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrandmaFight : MonoBehaviour
{
    private GameObject trig;
    public Animation Anim;
    public GameObject Player;
    bool touched = false;
    float timer_f = 0f;
    int timer_i = 0;
    int timer_i_f = 0;
    private bool Rope;
    private int state;
    private Scene scene;
    public GameObject A;
    public GameObject B;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        trig = GameObject.FindGameObjectWithTag("Attack");
        Rope = GameDataManager.Rope;
        state = GameDataManager.state;
        if (state != 3)
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
            if (scene.name != "SecondScene")
            {
                StartCoroutine(ToFightLose());
                Debug.Log("這是一場註定失敗的戰鬥");
                Anim.Play("SwitchFadeOut");
                touched = false;
            }
            else
            {
                StartCoroutine(ToFightWin());
                Debug.Log("這是一場有機會勝利的戰鬥");
                Anim.Play("SwitchFadeOut");
                touched = false;
            }
            if (Player.transform.position.x > A.transform.position.x &&
                Player.transform.position.x < B.transform.position.x)
            {
                GameDataManager.GrandMaCanDie = true;
            }

        }
        else if (touched == true)
        {
            if (timer_i - timer_i_f == 2)
            {
                Debug.Log("沒輸F");
                this.trig.SetActive(false);
                StartCoroutine(ToDead());
                GameDataManager.state = 3;
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
    IEnumerator ToFightLose()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GrandMaFightIN");
    }
    IEnumerator ToFightWin()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("GrandMaFightOUT");
    }
    IEnumerator ToDead()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("DeadScene");
    }
}
