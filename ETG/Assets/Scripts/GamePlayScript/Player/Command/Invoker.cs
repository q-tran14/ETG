using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker
{
    private ICommand[] commands;
    public void SetCommand(int pos, ICommand command)
    {
        if(commands[pos] != null)
        {
            commands[pos] = command;
        }
    }

    public void OnPress(int pos)
    {
        commands[pos].Execute();
    }
}
