using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public List<GameObject> dontDestroyOnLoadGameObj;
    public void OnEnable()
    {
        Time.timeScale = 0;
    }
    public void Restart()
    {
        foreach (GameObject go in dontDestroyOnLoadGameObj) DestroyImmediate(go);
        SceneManager.LoadScene(1);
        foreach (GameObject go in dontDestroyOnLoadGameObj) Instantiate(go);
    }
    public void Continue()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.ExitPlaymode();
    }
    public void OnDisable()
    {
        Time.timeScale = 1;
    }
}
