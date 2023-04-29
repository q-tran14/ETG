using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : Publisher
{
    public Player player;
    public bool onChange = false;
    public bool isFinishedTutorial = false;
    public HeartHealthSystem healthSystem;
    // Start is called before the first frame update
    void Start()
    {
        healthSystem = new HeartHealthSystem(player.health);
        notify("HP");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBullet" || collision.tag == "Hole" && GetComponent<StateManager>().loading.activeInHierarchy == false)
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
        if (collision.gameObject.tag == "Enemy")
        {
            DecreaseHPorShield();
        }
    }
    public void DecreaseHPorShield()
    {
        if (player.shield > 0)
        {
            player.shield -= 1;
            // Create Shock Wave here
        }
        else
        { 
            healthSystem.Damage();
            notify("HP");
        }
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
