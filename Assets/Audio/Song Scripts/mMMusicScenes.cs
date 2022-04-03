using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mMMusicScenes : MonoBehaviour
{
    // Start is called before the first frame update
    public MainMenuMusic mM;
    private void Awake()
    {
        mM.musicMPlaying = true;
    }

    private void Update(){
        mM.musicMPlaying = true;
    }
}
