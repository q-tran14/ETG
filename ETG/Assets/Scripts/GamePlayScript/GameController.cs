using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = hitObj();
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.gameObject.tag == "Player") 
                {
                    hit.collider.GetComponent<PlayerController>().enabled = true;
                    player = hit.collider.gameObject;
                }
            }
        }
    }

    public RaycastHit2D hitObj()
    {
        Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
        return hit;
    }
}
