using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 moveDirection;
    public float projectileSpeed = 5f;
    [SerializeField] private float timeDestroy = 3f;
    private void OnEnable()
    {
        Invoke("Destroy", timeDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * projectileSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

}