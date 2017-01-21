using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escape : MonoBehaviour {
    public GameObject Buttons;
	public GameObject ourButtons;
    // Use this for initialization
    void Start () {}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape))
        {
			Buttons.SetActive (true);
			ourButtons.SetActive (false);

        }
	}
}
