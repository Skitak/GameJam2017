using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour {

	public GameObject ShipInMovement;
	public static bool IsClick = false;

	private Vector3 origin;

	void Start () {
		origin = ShipInMovement.transform.position;
	}


	void Update () {
		if (!ShipManager.IsClick)
			ShipInMovement.transform.position = 
				new Vector3 (ShipInMovement.transform.position.x, 
					Mathf.Cos (origin.y * Time.time) * 0.2f, ShipInMovement.transform.position.z);
	}
}