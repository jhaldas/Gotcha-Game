using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenuMusic : MonoBehaviour
{
    public static MainMenuMusic mMusic;

    public AudioSource myAudioSource;
    public bool musicMPlaying = false;

    GameObject objToSpawn;

    private void Start()
    {
        mMusic = this;
        myAudioSource = GetComponent<AudioSource>();
        Debug.Log(musicMPlaying);
        if(GameObject.Find("MM Playing") == null){
            objToSpawn = new GameObject("MM Playing");
            myAudioSource.Play();
            DontDestroyOnLoad(this.objToSpawn);
            DontDestroyOnLoad(this);
        }
        return;
        
    }

    private void Update(){
    }
    
    public void mainMStop(){
        myAudioSource.Stop();
    }
}
