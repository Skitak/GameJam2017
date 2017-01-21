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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Front"))
        {
            float difference, myY, hisY;
            myY = this.transform.eulerAngles.y;
            hisY = other.transform.eulerAngles.y;
            if (myY < hisY)
                difference = other.transform.eulerAngles.y - this.transform.eulerAngles.y;
            else
            {
                difference = this.transform.eulerAngles.y - other.transform.eulerAngles.y;
            }
            transform.eulerAngles += new Vector3(0, difference / 2, 0);
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponentInParent<Player>().die();
            Debug.Log("euh");
        }
    }

    private void FixedUpdate()
    {
        rigid.velocity = transform.forward * m_speed;
    }
}
