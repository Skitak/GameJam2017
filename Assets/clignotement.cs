using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clignotement : MonoBehaviour 
{
	public Image image;
	float stateDuration = .2f;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		stateDuration -= Time.deltaTime;
		if(stateDuration <= 0 && image.enabled == true)
		{
			image.enabled = false;
			stateDuration = .2f;
		}
		if(stateDuration <= 0 && image.enabled == false)
		{
			image.enabled = true;
			stateDuration = .2f;
		}

	}
}
