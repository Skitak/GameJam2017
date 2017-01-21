using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private PlayerHead pH;

	void Start(){
		pH = GetComponentInChildren<PlayerHead> ();
	}


    public void die()
    {
		if(pH.getInvincible() == false )
        Destroy(this.gameObject);

    public void die()
    {
        //Destroy(this.gameObject);
        gameObject.SetActive(false);
        Invoke("Respawn", GameObject.Find("GameManager").GetComponent<GameManager>().respawnTime);
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
