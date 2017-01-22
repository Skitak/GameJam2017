using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject prefab_exp;

    private PlayerHead pH;
    private ParticleSystem explosion;

    void Start(){
		pH = GetComponentInChildren<PlayerHead> ();
        explosion = Instantiate(prefab_exp).GetComponent<ParticleSystem>();
        explosion.gameObject.SetActive(false);
    }




    public void die()
	{
		if (!pH.getInvincible ())
        {
            explosion.transform.position = transform.position;
            explosion.gameObject.SetActive(true);
            explosion.Play();

            //Destroy(this.gameObject);
            gameObject.SetActive (false);
			Invoke ("Respawn", GameObject.Find ("GameManager").GetComponent<GameManager> ().respawnTime);
		}
	}

    public void derive(GameObject other)
    {
        float difference,myY,hisY;
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

    public void Respawn()
    {
        GameObject spawnPoint = GameManager.getBestSpawnPoint(this.gameObject);
        transform.position = spawnPoint.transform.position;
        transform.rotation = spawnPoint.transform.rotation;
        gameObject.SetActive(true);
    }

}
