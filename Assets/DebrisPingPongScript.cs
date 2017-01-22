using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisPingPongScript : MonoBehaviour {

    public Vector3 pos1;

    public Vector3 pos2;

    public float speed = 1;

    private bool allez = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if ((transform.position == pos2 && allez) || (transform.position == pos1 && !allez))
            allez = !allez;


        if (allez)
            transform.position = Vector3.MoveTowards(transform.position, pos2, speed);

        else
            transform.position = Vector3.MoveTowards(transform.position, pos1, speed);

    }
}
