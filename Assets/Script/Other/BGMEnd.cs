using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMEnd : MonoBehaviour
{
    [SerializeField] private AudioSource Music;
    [SerializeField] private bool isFading;
    GameObject BGM1 = null;
    GameObject BGM2 = null;
    void Start()
    {
        BGM1 = GameObject.FindGameObjectWithTag("Sound1");
        BGM2 = GameObject.FindGameObjectWithTag("Sound2");
        if (BGM1 != null)
        {
            Debug.Log("本場景尚有音效1");
            SceneManager.MoveGameObjectToScene(BGM1, SceneManager.GetActiveScene());
            Music = BGM1.GetComponent<AudioSource>();
        }
        else if (BGM2 != null)
        {
            Debug.Log("本場景尚有音效2");
            SceneManager.MoveGameObjectToScene(BGM2, SceneManager.GetActiveScene());
            Music = BGM2.GetComponent<AudioSource>();
        }
        isFading = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            isFading = true;
        }
        if (isFading)
        {
            Music.volume = 1;//如果要從小聲到大聲.可以先將音量設定成0
            StartCoroutine(FadeMusic(Music, 2, 0));
        }
    }
    public static IEnumerator FadeMusic(AudioSource audioSource, float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = audioSource.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
