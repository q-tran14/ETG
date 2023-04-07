using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum State
    {

    }
    public Rigidbody2D rb;
    public float speed = 5f;
    public bool isInChamber = false;
    public bool isFinishedTutorial = false;
    public bool isDodging = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float ver = Input.GetAxis("Vertical");
        float hori = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2 (hori, ver)*speed;
        if((rb.velocity != null || rb.velocity != Vector2.zero) && isDodging == false)
        {
            isDodging = true;
            //Play animation Dodge
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isInChamber == false)
        {
            if(collision.gameObject.tag == "Door")
            {
                switch (collision.gameObject.name)
                {
                    case "TutorialDoor":
                        Debug.Log("Collider with Tutorial D");
                        break;
                    case "ShopDoor":
                        if (isFinishedTutorial == false)
                        {
                            Debug.Log("Blocked");
                            break;
                        }
                        Debug.Log("Collider with Shop D");
                        break;
                    case "ChamberEntrance":
                        if (isFinishedTutorial == false)
                        {
                            Debug.Log("Blocked");
                            break;
                        }
                        Debug.Log("Collider with Chamber Entrance");
                        break;
                }
            }
        }

        if (collision.gameObject.tag == "NPCs")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //NPC do something
            }
        }

        if (isDodging == true && collision.gameObject.tag == "Floor")
        {
            isDodging = false;
        }

    }
}
