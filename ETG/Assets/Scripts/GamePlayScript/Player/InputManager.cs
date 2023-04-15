using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //Command
    ICommand blank;
    ICommand charge;
    ICommand interact;
    ICommand openMenu;
    ICommand openItemList;
    ICommand openWeaponList;
    ICommand openMinimap;
    ICommand openAmmonomicon;

    //Receiver

    //Invoker
    Invoker invoker;
    private void Start()
    {
        invoker = new Invoker();

        blank = new Blank();
        charge = new Charge();
        interact = new Interact();
        openMenu = new OpenMenu();
        openItemList = new OpenItemList();
        openWeaponList = new OpenWeaponList();
        openMinimap = new OpenMinimap();
        openAmmonomicon = new OpenAmmonomicon();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Blank
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            // Interact
        }
        
        if (Input.GetKeyUp(KeyCode.R))
        {
            // Charge
        }

        if (Input.GetKeyUp(KeyCode.I))
        {
            // Open ammonomico
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            // Open minimap
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            // Open item list
        }

        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
        {
            // Open weapon list
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Open menu
        }
    }
}
