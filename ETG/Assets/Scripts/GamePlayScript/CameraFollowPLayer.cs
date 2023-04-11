using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPLayer : MonoBehaviour
{
    public GameController controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(controller.player != null)
        {
            transform.position = new Vector3(controller.player.transform.position.x, controller.player.transform.position.y,-10);
        }
        else
        {
            transform.position = new Vector3(6f,-2f,-10f);
        }
    }
}
