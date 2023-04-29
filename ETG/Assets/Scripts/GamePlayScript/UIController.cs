using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }
    public Canvas canvas;
    public GameObject hegemony;
    public GameObject facecard;
    public GameObject loading;
    public GameObject inChamber;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(canvas);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void FixedUpdate()
    {
        //if(loading.activeInHierarchy == false)
        //{
        string sceneName = SceneManager.GetActiveScene().name;
        switch (sceneName)
        {
            case "TheBreach":
            case "Shopping":
                hegemony.SetActive(true);
                inChamber.SetActive(false);
                break;
            case "Start":
                hegemony.SetActive(false);
                inChamber.SetActive(false);
                break;
            default:
                hegemony.SetActive(false);
                inChamber.SetActive(true);
                break;

        }
        //}
    }
}
