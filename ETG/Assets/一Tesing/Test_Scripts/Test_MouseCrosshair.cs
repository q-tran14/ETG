using UnityEngine;
using UnityEngine.InputSystem;

public class Test_MouseCrosshair : MonoBehaviour
{
    private Vector2 mousePos;
    private Vector3 worldPos;
    private Camera mainCamera;

    private void Start() {
        mainCamera = Camera.main;
        Cursor.visible = false;
    }

    public void OnLook(InputAction.CallbackContext context) {
        mousePos = context.ReadValue<Vector2>();
        
    }

    private void Update() {
        worldPos = mainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
        gameObject.transform.position = worldPos;
    }
}
