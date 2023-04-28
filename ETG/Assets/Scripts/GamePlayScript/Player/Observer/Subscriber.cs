using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subscriber
{
    public abstract void OnNotify(string eventName);
}
