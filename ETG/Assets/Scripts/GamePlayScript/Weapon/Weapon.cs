using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    // Use for display in UI
    public Sprite idleSprite;
    public Sprite bulletIdle;

    // Use for fire action
    public GameObject projectile;
    public float dmg;
    public float speed;
    public int bulletAmountPerTime;
    public float timeToRecharge;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
