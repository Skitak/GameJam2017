using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour {

    [FMODUnity.EventRef]
    public string destruction;
    private FMOD.Studio.EventInstance destructionEvent;

    [FMODUnity.EventRef]
    public string contact;
    private FMOD.Studio.EventInstance contactEvent;

    [FMODUnity.EventRef]
    public string hit;
    private FMOD.Studio.EventInstance hitEvent;

    void Start()
    {
        destructionEvent = FMODUnity.RuntimeManager.CreateInstance(destruction);

        contactEvent = FMODUnity.RuntimeManager.CreateInstance(contact);

        hitEvent = FMODUnity.RuntimeManager.CreateInstance(hit);
    }

    public void OnDie()
    {
        destructionEvent.start();
    }

    public void OnHit()
    {
        hitEvent.start();
    }

    public void OnContact()
    {
        contactEvent.start();
    }
}
