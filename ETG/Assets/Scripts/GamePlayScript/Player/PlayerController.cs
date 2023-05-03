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
    public bool damaged = false;
    public float timer;
    public GameObject hand;
    public int currentWeapon = 0;
    // Start is called before the first frame update
    
    void Start()
    {
        healthSystem = new HeartHealthSystem(player.health);
        notify("All", "", 0);
        player.weapons[currentWeapon].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        SetWeaponForState();
        if (damaged == true) timer += Time.deltaTime;
    }
    private void FixedUpdate()
    {
        if(timer > 1.5f)
        {
            damaged = false;
            timer = 0;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "EnemyBullet" || collision.tag == "Hole") && GetComponent<StateManager>().loading.activeInHierarchy == false && GetComponent<StateManager>().weaponActive == true && GetComponent<InputManager>().isBlanking == false && damaged == false)
        {
            DecreaseShieldOrHeart();

        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Weapon")
        {
            notify("WeaponList","",0);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            DecreaseShieldOrHeart();
        }
    }

    void DecreaseShieldOrHeart()
    {
        damaged = true;
        if (player.shield > 0)
        {
            GetComponent<InputManager>().isBlanking = true;
            player.shield -= 1;
            GetComponent<InputManager>().invoker.OnPress(0);
            notify("Shield", "Sub", 0);
        }
        else if (player.shield == 0)
        {
            healthSystem.Damage();
            notify("HP", "", 0);
        }
    }

    public void SetWeapon(GameObject weapon)
    {
        GameObject w = Instantiate(weapon,Vector3.zero,Quaternion.identity) as GameObject;
        w.transform.SetParent(hand.transform);
        w.transform.localPosition = new Vector3(0.43f, 0.11f, 0);
        player.addInList(w);
        w.SetActive(false);
    }

    public void SetWeaponForState()
    {
        foreach (GameObject w in player.weapons)
        {
            if (w.activeInHierarchy == true)
            {
                GetComponent<StateManager>().weapon = w;
                return;
            }
        }
        GetComponent<StateManager>().weapon = player.weapons[0];

    }
}
