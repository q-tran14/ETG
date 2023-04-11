using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateManager: MonoBehaviour 
{
    public PlayerController controller;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    IState currentState;
    public IState previousState;
    IState selectState = new SelectState();
    public float ver, hori, speed = 5f;
    public Rigidbody2D rb;

    public bool isInChamber = false;
    public bool isDodging = false;
    public bool hasGun = false;
    public bool isOnFloor;
    public Vector3 lastPos; 

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        currentState = selectState;
        previousState = currentState;
        currentState.SetSide("S", "S");
        currentState.SetManager(this);
        currentState.EnterState();
    }

    // Update is called once per frame
    private void Update()
    {
        ver = Input.GetAxis("Vertical");
        hori = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(hori, ver) * speed;
        if (Input.GetMouseButtonDown(1) && isDodging == false)
        {
            isDodging = true;
        }
        currentState.UpdateState();
        Debug.Log(currentState.GetType().Name);
        if(isOnFloor) lastPos = transform.position;
    }

    public void SwitchState(IState newState)
    {
        if(previousState != currentState)
        {
            previousState = currentState;
        }
        currentState = newState;
        currentState.SetSide(previousState.previous_side_hori,previousState.previous_side_ver);
        currentState.SetManager(this);
        currentState.EnterState();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Door")
        {
            Debug.Log("Collision door");
            SwitchState(new RunBackDoorWayState());
        }
        if (collision.tag == "Hole" && isDodging == false)
        {
            isOnFloor = false;
            SwitchState(new PitfallState());
        }
        if(collision.tag == "Floor")
        {
            isOnFloor = true;
            
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Hole" && isDodging == false)
        {
            SwitchState(new PitfallState());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
