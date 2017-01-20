using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generique : MonoBehaviour {
    public GameObject Buttons;
    public GameObject EscapeObj;

    // Use tis for initialization
    void Start()
    {
        Buttons = GameObject.FindWithTag("Buttons");
        EscapeObj = GameObject.FindWithTag("EscapeTag");
        EscapeObj.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RunGeneric()
    {
        Buttons.SetActive(false);
        EscapeObj.SetActive(true);
    }
}
