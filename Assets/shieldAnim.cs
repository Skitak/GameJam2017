using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldAnim : MonoBehaviour 
{
	float animSpeed = 3.5f;
	Renderer rend;

	// Use this for initialization
	void Start () 
	{
		rend = GetComponent<Renderer> ();

		//StartCoroutine (Fade ());
	}
	
	// Update is called once per frame
	void Update () 
	{
		StartCoroutine (Fade ());

		float offset = Time.time * animSpeed;
		rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
		rend.material.SetTextureOffset("_EmissionMap", new Vector2(0, offset));
	}

	public IEnumerator Fade () 
	{
		for (float f = 1f; f >= 0; f -= 0.008f) 
		{
			Color c = GetComponent<Renderer> ().material.color;
			c.a = f;
			GetComponent<Renderer> ().material.color = c;
			yield return null;
		} 
		Color c2 = GetComponent<Renderer> ().material.color;
		c2.a = 1f;
		GetComponent<Renderer> ().material.color = c2;
		gameObject.SetActive(false);
	}

	public void show(){
		gameObject.SetActive (true);
	}
}
