using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicControl : MonoBehaviour
{      
    [SerializeField] private AudioSource Music;
    [SerializeField] public Scene scene;
    [SerializeField] private bool isFading;
    // Start is called before the first frame update
    void Start()
    {   
        Music = GetComponent<AudioSource>();
        isFading = false;
        // DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)){
            isFading = true;
        }
        if(isFading){
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
