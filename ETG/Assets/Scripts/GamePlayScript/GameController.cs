using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController gController { get; private set; }
    public GameObject playerObj; // Player Game Obj
    public bool isWin = false;
    public Player playerData; // Data while explore chamber
    public UserData userData; // Data storage per time when meet new weapon, item, enemy, boss

    
    private void Awake()
    {
        if (gController != null && gController != this)
        {
            Destroy(this);
        }
        else
        {
            gController = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        ChoosePlayer();

    }

    void GameOver() //Handle lose or win game event
    {

    }

    void onDamageEvent() // Damage Event
    {

    }
    public RaycastHit2D hitObj()
    {
        Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
        return hit;
    }

    void ChoosePlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = hitObj();
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    playerObj = hit.collider.gameObject;
                    playerObj.GetComponent<PlayerController>().enabled = true;
                    if (playerObj.name == "Hunter")
                    {
                        foreach(CharacterData c in GameObject.Find("CharacterData")?.GetComponent<Characters>().characterData)
                        {
                            if(c.name == playerObj.name)
                            {
                                playerData = new Player(c);
                                playerObj.GetComponent<PlayerController>().player = playerData;
                                break;
                            }
                        }
                        
                    }
                    DontDestroyOnLoad (playerObj);
                    
                }
            }
        }
    }
}
