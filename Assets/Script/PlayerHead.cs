using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    /*private void OnCollisionEnter(Collision other)
    {
        Debug.Log("done");
        if (other.gameObject.CompareTag("Player"))
            other.gameObject.GetComponentInParent<Player>().die();
        else
            GetComponentInParent<Player>().die();
    }*/

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("done");
        if (other.gameObject.CompareTag("Player"))
            other.gameObject.GetComponentInParent<Player>().die();
        else if (other.gameObject.CompareTag("Front"))
            GetComponentInParent<Player>().derive(other.gameObject);
        else if (other.gameObject.CompareTag("Wall"))
        {
            GetComponentInParent<Player>().die();
            //transform.parent.forward *= -1;
        }
        else
            GetComponentInParent<Player>().die();
    }


}
