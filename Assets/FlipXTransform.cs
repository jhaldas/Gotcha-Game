using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipXTransform : MonoBehaviour
{
    // Start is called before the first frame update

    private SpriteRenderer sprite;
    public VacuumAim aim;
    public bool facingRight = true;

    Vector3 scaleChange = new Vector3(-1, 1, 1);

    void Update()
    {
        if(aim.facingRight != facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 lTemp = transform.localScale;
        lTemp.x *= -1;
        transform.localScale = lTemp;
    }
}
