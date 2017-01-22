using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManage2 : MonoBehaviour {

	public GameObject[] players;
	public GameObject[] spawners;
	public float respawnTime;
	public float nbScoreRequired = 100.0f;

	private float timer;
	private static GameManage2 instance;

	void Awake(){
		if (instance == null)
			instance = this;
		else
			Debug.Log ("HAHAHHAHAHA");
		
	}

	void Start (){
		foreach (GameObject player in instance.players) {
			Slider slider = player.GetComponent<Player> ().slider;
			slider.maxValue = nbScoreRequired;
		}
	}


	void end()
	{
		GameObject winner = null;
		float nbScore = 0;
		foreach (GameObject gm in players)
		{
			if (gm.GetComponentInChildren<Player>().getScore() > nbScore)
			{
				nbScore = gm.GetComponentInChildren<Player>().getScore();
				winner = gm;
			}
		}

		won();
	}

	public static GameObject getBestSpawnPoint(GameObject playerOut)
	{
		//calcul de la moyenne des positions des autres joueurs
		Vector3 moyenne = Vector3.zero;

		foreach(GameObject player in instance.players)
		{
			if(player != playerOut)
			{
				moyenne += player.transform.position;
			}
		}
		moyenne /= (instance.players.Length - 1);

		float distance = 0;
		GameObject spawnPoint = null;
		foreach(GameObject point in instance.spawners)
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

	public static float getScoreRequired(){
		return instance.nbScoreRequired;
	}

	public void won(){
	
	}
}
