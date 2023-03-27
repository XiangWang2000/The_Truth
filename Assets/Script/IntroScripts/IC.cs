using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IC : MonoBehaviour
{
    public Animation Anim;
    public Scene scene;
    private AudioSource ButtonAudio;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        ButtonAudio = GetComponent<AudioSource>();
    }
    void LoadMap(string map)
    {
        Application.LoadLevel(map);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ButtonAudio.Play(0);
            Debug.Log(scene.name);
            switch (scene.name)
            {
                case "Intro1": Anim.Play("O1"); break;
                case "Intro2": Anim.Play("O2"); break;
                case "Intro3": Anim.Play("O3"); break;
                case "Intro4": Anim.Play("O4"); break;
                case "Intro5": Anim.Play("O5"); break;
                case "Intro6": Anim.Play("O6"); break;
                case "Intro7": Anim.Play("O7"); break;
                case "Intro8": Anim.Play("O8"); break;
                case "Intro9": Anim.Play("O9"); break;
            }
        }
    }
}
