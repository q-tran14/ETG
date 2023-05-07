using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Elevator : MonoBehaviour
{
    public Collider2D under;
    public bool comeAndGo;
    public string sceneName;
    public GameObject player;
    public bool justCome;
    private void Start()
    {
        if (justCome == true)
        {
            GetComponent<Animation>().Play("Open");
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player" && comeAndGo == true)
        {
            GetComponent<Animator>().Play("Close");
        }
    }
}
