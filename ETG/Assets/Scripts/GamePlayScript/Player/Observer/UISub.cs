using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISub : MonoBehaviour,Subscriber
{
    public GameObject heartCounter;
    public void OnNotify(string eventName)
    {
        switch (eventName)
        {
            case "HP":
                heartCounter.GetComponent<HeartHealthVisual>().HeartHealthSystemHaveChange();
                break;
            case "Blank":
                break ;
            case "Coin":
                break;
            case "Key":
                break;
            case "Shield":
                break;
            case "WeaponList":
                break;
            case "ItemList":
                break;
        }
    }

    private void OnEnable()
    {
        Publisher.Subcribe(this);
    }

    private void OnDisable()
    {
        Publisher.Unsubcribe(this);
    }
}
