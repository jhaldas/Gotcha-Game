using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip jump, gameEnd, suck, vacuumEmpty, dead, newSuck;
    public static AudioSource audioSrc;
    public static float myVolume = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        jump = Resources.Load<AudioClip>("jump");
        gameEnd = Resources.Load<AudioClip>("gameEnd");
        newSuck = Resources.Load<AudioClip>("newSuck");
        vacuumEmpty = Resources.Load<AudioClip>("vacuumEmpty");
        dead = Resources.Load<AudioClip>("dead");
        
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        print(audioSrc);
    }

    public static void PlaySound(string clip)
    {
        switch(clip){
        case"jump":
            audioSrc.PlayOneShot(jump, myVolume);
            break;
        case"gameEnd":
            audioSrc.PlayOneShot(gameEnd, myVolume);
            break;
        case"newSuck":
            audioSrc.PlayOneShot(newSuck, myVolume);
            break;
        case"vacuumEmpty":
            audioSrc.PlayOneShot(vacuumEmpty, myVolume);
            break;
        case"dead":
            audioSrc.PlayOneShot(dead, myVolume);
            break;
        }
    }

}
