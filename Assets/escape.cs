using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escape : MonoBehaviour {
    public GameObject Buttons;
    // Use this for initialization
    void Start () {
        Buttons = GameObject.FindWithTag("Buttons");
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape))
        {
            Buttons.SetActive(true);
            gameObject.SetActive(false);
        }
	}
}
