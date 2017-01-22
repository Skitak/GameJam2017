using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeCollider : MonoBehaviour {

    private PlayerSound audio;

    void Start()
    {
        audio = GetComponent<PlayerSound>();
    }

    void OnTriggerEnter()
    {
        audio.OnContact();
    }
}
