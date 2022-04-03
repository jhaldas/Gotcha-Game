using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class musicOn : MonoBehaviour
{
    GameObject musicOnBox;
    public bool musicOnT = true;
    void Start()
    {
        musicOnBox = GameObject.Find("Music");
    }

    
    void Update()
    {
        
    }

    public bool musicOnTrue()
    {
        if (musicOnBox.GetComponent<Toggle>().isOn == true)
        {
            musicOnT = true;
        }
        else 
        {
            musicOnT = false;        
        }
        return musicOnT;
    }
}
