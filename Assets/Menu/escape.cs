using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escape : MonoBehaviour {
    public GameObject ButtonsMenu;
	public GameObject ourButtons;
	public GameObject ButtonsSelection;

    void Start () {}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Cancel"))
        {
			ButtonsMenu.SetActive (true);
			ourButtons.SetActive (false);
			ButtonsSelection.SetActive (false);
        }
	}
}
