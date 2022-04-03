using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSpriteX : MonoBehaviour
{
    // Start is called before the first frame update

    private SpriteRenderer sprite;
    public VacuumAim aim;
    public bool facingRight = true;

    void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(aim.facingRight == true)
        {
            sprite.flipX = facingRight;
        }
        else if(aim.facingRight == false)
        {
            sprite.flipX = !facingRight;
        }
    }
}
