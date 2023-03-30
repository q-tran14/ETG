using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Character_Animation : MonoBehaviour
{   
    private Animator animator;
    private SpriteRenderer sprite;
    private Test_Character_Movement characterMovement;
    private Test_MouseCrosshair crosshair;

    // const name for animation clip
    private const string IDLE_BACK = "idle_back";
    private const string IDLE_BACK_RIGHT = "idle_back_right";
    private const string IDLE_FRONT = "idle_front";
    private const string IDLE_FRONT_RIGHT = "idle_front_right";

    private string currentState;

    // Start is called before the first frame update
    void Start()
    {
        characterMovement = GetComponent<Test_Character_Movement>();
        animator = GetComponentInChildren<Animator>();    
        sprite = GetComponentInChildren<SpriteRenderer>();
        crosshair = GetComponentInChildren<Test_MouseCrosshair>();
    }

    // Update is called once per frame
    void Update()
    {
        CrosshairToAnimation();
    }

    void ChangeState(string newState) {

        // stop current animation to interrupt itself    
        if(newState == currentState) return;

        // play the animation
        animator.Play(newState);

        // reassign the state
        currentState = newState;
    }

    void CrosshairToAnimation() {
        // Flip sprite in mouse on the left
        if(crosshair.transform.localPosition.x > 0){
            sprite.flipX = false;
        } else {
            sprite.flipX = true;
        }

        // PLay animation according to y position
        // if(crosshair.transform.position.y > 0){
            
        // } else {
            
        // }    

        switch(crosshair.transform.localPosition.y) {
            case > 0:
                ChangeState(IDLE_BACK_RIGHT);
                break;
            case < 0:
                ChangeState(IDLE_FRONT_RIGHT);
                break;      
            default:
                Debug.Log("Invalid level");
                break;
        }

    }
}
