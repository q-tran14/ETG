using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Publisher 
{
    private List<Subscriber> subscribers;
    public enum eventName
    {
        None,
        Player,
        Boss,
    }

    private eventName eventN;

    public void subcribe(Subscriber s)
    {
        subscribers.Add(s);
    }

    public void notify(int i,string detailChange)
    {
        subscribers[i].OnNotify(detailChange);
    }

    public void onSomethingChange(string objChange,string detailChange)
    {
        if (subscribers.Count != 0)
        {
            switch (objChange)
            {
                case "Player": // Change on Player
                    notify(1,detailChange);
                    break;
                case "Boss": // Chnage on Boss
                    notify(2,detailChange);
                    break;
            }
        }
    }
}
