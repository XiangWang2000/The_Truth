using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadF1 : MonoBehaviour
{   
    private int [] Propos;
    public GameObject Pot;
    public GameObject Album;
    public GameObject Rope;
    
    // Start is called before the first frame update
    void Awake()
    {   
        private GameObject [] p = {Rope,Album,Pot};
        Propos = GameDataManager.Propos;
        for (int i = 0 ; i < p.Length ; i++ ){
            if(Propos[i]==1){
                Destroy(p[i]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
