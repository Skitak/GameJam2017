using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cometeScript : MonoBehaviour 
{
    private Rigidbody rigid;
    public float m_speed = 10;
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
		Destroy (gameObject, 10);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Front"))
        {
			transform.eulerAngles = other.transform.eulerAngles;
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponentInParent<Player>().die();
        }
    }

    private void FixedUpdate()
    {
        rigid.velocity = transform.forward * m_speed;
    }
		
}
