using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Manager : MonoBehaviour {

	protected static Manager manager;

	public GameObject[] players;
	public GameObject[] spawners;
	public float respawnTime;
    public GameObject buttons;

	public static GameObject getBestSpawnPoint(GameObject playerOut)
	{
		//calcul de la moyenne des positions des autres joueurs
		Vector3 moyenne = Vector3.zero;
		foreach(GameObject player in manager.players)
		{
			if(player != playerOut)
			{
				moyenne += player.transform.position;
			}
		}
		moyenne /= (manager.players.Length - 1);

		float distance = 0;
		GameObject spawnPoint = null;
		foreach(GameObject point in manager.spawners)
		{
			float distanceNew = (moyenne - point.transform.position).magnitude;
			if(distanceNew >= distance)
			{
				distance = distanceNew;
				spawnPoint = point;
			}
		}
		return spawnPoint;
	}

    public static float respawnTimer()
    {
        return manager.respawnTime;
    }

	public static void won (Player p){
        manager.buttons.SetActive(true);
        manager.buttons.GetComponentInChildren<Text>().text = p.gameObject.name + " wins";
	}

    public static bool deathMatch()
    {
        return manager is GameManager;
    }

    public static bool captureFlag()
    {
        return !deathMatch();
    }

    public void endAction()
    {
        //TODO
    }
}
