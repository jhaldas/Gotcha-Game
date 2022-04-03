using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Level1Music : MonoBehaviour
{
    public MainMenuMusic mM;
    private void Awake()
    {
        mM.musicMPlaying = false;
        Destroy(GameObject.Find("MainMusic"));
    }

    private void Update(){
        mM.musicMPlaying = false;
        Destroy(GameObject.Find("MainMusic"));
        Destroy(GameObject.Find("MM Playing"));
    }
    
}
