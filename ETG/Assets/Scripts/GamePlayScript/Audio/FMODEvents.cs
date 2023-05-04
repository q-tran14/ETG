using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Player SFX")]
    [field: SerializeField] public EventReference playerFootsteps { get; private set; }

    [field: Header("Bullet Shot SFX")]
    [field: SerializeField] public EventReference bulletShot { get; private set; }


    public static FMODEvents instance { get; private set; }
}