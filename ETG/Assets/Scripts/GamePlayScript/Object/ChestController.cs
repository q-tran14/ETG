using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    [Header("Fragments Settings")]
    public List<GameObject> itemsList;

    [Header("Spawn Settings")]
    private Animator animator;
    private bool hasOpened = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
     private void Start() {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionStay2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player") && !hasOpened)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.Play("open");
                spawnAction();
                hasOpened = true;
            }
        }
    }
    private void spawnAction()
    { 
        foreach (GameObject items in itemsList)
        {
            GameObject item = Instantiate(items, transform.position, Quaternion.identity);
            Vector2 randomDirection = Random.insideUnitCircle.normalized;                       //Set the direction
            Vector2 randomVelocity = randomDirection * 5 * Random.Range(0.1f, 1f);     //Set the velocity

            Rigidbody2D rb = item.GetComponent<Rigidbody2D>();
            rb.AddForce(randomVelocity, ForceMode2D.Impulse);
            rb.AddTorque(30);      //Add a random torque to make the fragment rotate randomly
            StartCoroutine(DisableMovement(rb));     //Stop move

        }
    }

    private IEnumerator DisableMovement(Rigidbody2D rb)
    {
        yield return new WaitForSeconds(0.5f);
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0.0f;
    }

}
