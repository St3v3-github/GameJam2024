using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Whoopie SFX")]
    [field: SerializeField] public EventReference FartSound { get; private set; }

    [field: Header("Shock SFX")]
    [field: SerializeField] public EventReference ShockSound { get; private set; }

    [field: Header("Door SFX")]
    [field: SerializeField] public EventReference DoorSound { get; private set; }

    [field: Header("Fire Start SFX")]
    [field: SerializeField] public EventReference IgnitionSound { get; private set; }

    [field: Header("Kill Splatter SFX")]
    [field: SerializeField] public EventReference SplatterSound { get; private set; }

    [field: Header("Player Laugh SFX")]
    [field: SerializeField] public EventReference Player_LaughSound { get; private set; }

    [field: Header("Boss Laugh SFX")]
    [field: SerializeField] public EventReference Boss_LaughSound { get; private set; }

    [field: Header("Crowd Laugh SFX")]
    [field: SerializeField] public EventReference Crowd_LaughSound { get; private set; }

    [field: Header("Gunshot SFX")]
    [field: SerializeField] public EventReference GunSound { get; private set; }

    [field: Header("item SFX")]
    [field: SerializeField] public EventReference itemSound { get; private set; }

    [field: Header("Poisoned SFX")]
    [field: SerializeField] public EventReference PoisonSound { get; private set; }

    [field: Header("Scream SFX")]
    [field: SerializeField] public EventReference ScreamSound { get; private set; }

    [field: Header("Dialogue SFX")]
    [field: SerializeField] public EventReference DialogueSound { get; private set; }

    [field: Header("Music")]
    [field: SerializeField] public EventReference music { get; private set; }

    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found >1 events. ");
        }
        instance = this;
    }
}
