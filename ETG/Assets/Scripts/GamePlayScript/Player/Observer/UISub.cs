using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISub: Subscriber
{
    // Heart Counter - image
    // Blank Counter - image
    // Coin Counter - text
    // Key Counter - text
    // Weapon List - Scroll list
    // Passive Item List - Scroll list
    // Active Item List - Scroll list

    // Boss health bar - 

    public UISub()
    {

    }

    public override void OnNotify(string evenName)
    {
        switch (evenName)
        {
            case "Health":
                break;
            case "Blank":
                break;
            case "Key":
                break;
            case "Coin":
                break;
            case "Weapon List":
                break;
            case "Passive Item List":
                break;
            case "Active Item List":
                break;
            case "BossHPChange":
                break;
            case "BossDie":
                break;
        }
    }
}
