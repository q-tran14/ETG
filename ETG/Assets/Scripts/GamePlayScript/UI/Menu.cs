using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public List<GameObject> currentInScene;
    public List<GameObject> prefabDontDestroyOnLoadObj;
     
    public void OnEnable()
    {
        Time.timeScale = 0;
    }
    public void Restart()
    {
        foreach (GameObject go in currentInScene)
        {
            GameObject b = Instantiate(go);
            prefabDontDestroyOnLoadObj.Add(b);
            currentInScene.Remove(go);
            DestroyImmediate(go);
        }
        foreach (GameObject go in prefabDontDestroyOnLoadObj)
        {
            currentInScene.Add(go);
        }
        SceneManager.LoadScene(1);
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
