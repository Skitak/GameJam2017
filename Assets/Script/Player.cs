using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public GameObject prefab_exp;

	public int nbPtsSec;
	public Slider slider;

    private PlayerHead pH;
    private ParticleSystem explosion;

	private float nbScore;

    void Start(){
		pH = GetComponentInChildren<PlayerHead> ();
        explosion = Instantiate(prefab_exp).GetComponent<ParticleSystem>();
        explosion.gameObject.SetActive(false);
    }


	void Update(){
		if (pH.getFlagged () == true) {
			nbScore += (float) nbPtsSec * Time.deltaTime;
			slider.value = nbScore;
		}

	}

    public void die()
	{
		if (!pH.getInvincible ())
        {
            explosion.transform.position = transform.position;
            explosion.gameObject.SetActive(true);
            explosion.Play();
			if (pH.getFlagged () == true) {
				pH.getFils().transform.DetachChildren();
				pH.setFlagged (false);
			}

            //Destroy(this.gameObject);
            gameObject.SetActive (false);
			//if(GameObject.Find("GameManager").GetComponents<GameManager>() == null)
			Invoke ("Respawn", GameObject.Find ("GameManager").GetComponent<GameManage2> ().respawnTime);
			//else
				//Invoke ("Respawn", GameObject.Find ("GameManager").GetComponent<GameManager> ().respawnTime);
			
		}
	}

    public void derive(GameObject other)
    {
        /*float difference,myY,hisY;
        myY = this.transform.eulerAngles.y;
        hisY = other.transform.eulerAngles.y;
        if (myY < hisY)
            difference = other.transform.eulerAngles.y - this.transform.eulerAngles.y;
        else
        {
            difference = this.transform.eulerAngles.y - other.transform.eulerAngles.y;
        }
        transform.eulerAngles += new Vector3(0, difference / 2, 0);*/

		Rigidbody otherRigidbody = other.gameObject.GetComponentInParent<Rigidbody> ();
		Rigidbody myRigidbody = GetComponent<Rigidbody> ();
		float myAngle = transform.eulerAngles.y;
		float otherAngle = other.transform.eulerAngles.y;

		float myVelocity = GetComponent<Deplacement>().SpeedUpdate();
		float otherVelocity = other.GetComponentInParent<Deplacement>().SpeedUpdate();

		float angleDesired = Vector3.Angle (other.transform.forward, transform.forward);
		float multiplier;
		float direction = (transform.forward.z * other.transform.forward.z > 0 ? -1 : 1);
		if (myVelocity > otherVelocity) {
			multiplier = (myVelocity - otherVelocity) / GetComponent<Deplacement>().vMax;

		} else {
			angleDesired = 180f - angleDesired;
			multiplier =  1 - ((myVelocity - otherVelocity) / GetComponent<Deplacement>().vMax);
			direction *= -1;
		}
		float actualAngle = angleDesired * multiplier * direction + otherAngle;
		Vector3 angle = new Vector3 (0, actualAngle, 0);
		transform.eulerAngles = angle;


    }

    public void Respawn()
    {
        GameObject spawnPoint = GameManage2.getBestSpawnPoint(this.gameObject);
        transform.position = spawnPoint.transform.position;
        transform.rotation = spawnPoint.transform.rotation;
        gameObject.SetActive(true);
    }

	public float getScore(){
		return nbScore;
	}

}
