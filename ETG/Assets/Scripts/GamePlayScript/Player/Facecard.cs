using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class Facecard : MonoBehaviour
{
    public GameObject panel;
    public Vector2 offset;
    // Start is called before the first frame update
    private void LateUpdate()
    {
        if (gameObject.GetComponent<PlayerController>().enabled == true)
        {
            gameObject.GetComponent<Facecard>().enabled = false;
        }
    }
    private void OnMouseEnter()
    {
        RectTransform panelPos = panel.GetComponent<RectTransform>();
        panelPos.position = RectTransformUtility.WorldToScreenPoint(Camera.main, transform.position) + offset;
        if(gameObject.GetComponent<PlayerController>().enabled == false)
        {
            panel.SetActive(true);
        }
        
    }

    private void OnMouseExit()
    {
        panel.SetActive(false);
    }
}
