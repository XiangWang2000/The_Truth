using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacktoFirst : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameDataManager.backfromalbum = true;
        Debug.Log(GameDataManager.backfromalbum);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
