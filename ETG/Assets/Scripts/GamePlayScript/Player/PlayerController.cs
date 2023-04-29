using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Player player;
    public bool onChange = false;
    public bool isFinishedTutorial = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            if(collision.GetComponent<Enemy.Enemy>().canCollision == false)
            {
                DecreaseHPorShield();
            }
        }

        if (collision.tag == "EnemyBullet" || collision.tag == "Hole")
        {
            DecreaseHPorShield();
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Item")
        {
            
        }

        if(collision.gameObject.tag == "Weapon")
        {

        }
    }
    public void DecreaseHPorShield()
    {
        if (player.shield > 0)
        {
            player.shield -= 1;
            // Create Shock Wave here
        }
        else player.health -= 1;
    }

    public void GetItem(string name)
    {
        switch (name)
        {
            case "Heart":
                break;
            case "Blank":
                break;
            case "Shield":
                break;
            case "SilverKey":
                break;
            case "GoldKey":
                break;
            case "Shell":
                break;
            default:
                break;
        }
    }
}
