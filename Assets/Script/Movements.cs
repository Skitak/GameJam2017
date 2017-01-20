using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour {

    private Rigidbody rigid;
    private Vector3 direction;

    public float m_speed = 10;


	void Start () {
        rigid = this.GetComponent<Rigidbody>();
        move(new Vector3(0, 0, 1));
	}

    private void FixedUpdate()
    {
        rigid.velocity = Vector3.forward * m_speed;
    }

    public void move(Vector3 input)
    {
        direction = input;
        this.transform.Rotate(input);
    }
}
