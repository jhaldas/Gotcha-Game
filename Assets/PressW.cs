using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressW : MonoBehaviour
{

    public SceneController sc;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            sc.Menu();
        }
    }
}
