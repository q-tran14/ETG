using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    // Use for display in UI
    [Header("Display in UI")]
    public Sprite idleSprite;
    public Sprite bulletIdle;

    // Use for fire action
    [Header("Spawn bullet position")]
    public Transform spawnBullet; // previous name : shootingPoint
    public GameObject projectilePrefab;
    public float projectileSpeed;
   
    public float dmg;
    public int bulletAmountPerTime; // ammo
    public float timeToRecharge; // reload ammo
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public abstract void ShootingBullet();
}
