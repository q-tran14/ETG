using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test_Character_Movement : MonoBehaviour
{
    public float speed = 100f;

    Vector2 inputVector;

    public void OnMove(InputAction.CallbackContext context)
    {
        // read the value for the "move" action each event call
        inputVector = context.ReadValue<Vector2>();
        
    }

    public Vector2 GetInputVector() {
        return inputVector;
    }

    private void Update() {
        Vector3 moveDirection = new Vector3(inputVector.x, inputVector.y, 0); 
        gameObject.transform.position += moveDirection * speed * Time.deltaTime;
    }
}
