using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public float currentPoints = 0;
    public float maxSuck = 5f;
    public float suckLeft;
    public float suckRegenRate;
    public float suckDepletionRate;
    public bool isSucking;


    // Start is called before the first frame update
    void Start()
    {
        isSucking = false;
        suckLeft = maxSuck;
    }

    // Update is called once per frame
    void Update()
    {
        if(isSucking == true)
        {
            DepleteSuck();
        }
        else
        {
            RegenSuck();
        }
    }

    public void SetIsSucking(bool val)
    {
        isSucking = true;
    }

    public void RegenSuck()
    {
        suckLeft += suckRegenRate;

        if(suckLeft < maxSuck)
        {
            suckLeft += suckRegenRate;  
        }
        else
        {
            suckLeft = maxSuck;
        }
    }

    public void DepleteSuck()
    {
        if(suckLeft >= 0)
        {
            suckLeft -= suckDepletionRate;  
        }
        else
        {
            suckLeft = 0;
        }

    }
}
