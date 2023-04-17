using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMan : Enemy
{
    
    

    public override void Fire()
    {
        return;
    }

    public override void State()
    {
        if(base.target.transform.position.x < transform.position.x)
        {

        }
        if(base.target.transform.position.x > transform.position.x)
        {

        }
        return;
    }

    IEnumerator FireDelay()
    {

        yield return new WaitForSeconds(1.5f);
    }
}
