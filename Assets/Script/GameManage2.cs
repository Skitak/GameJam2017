using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManage2 : Manager {

	public float nbScoreRequired = 100.0f;

	private float timer;

	void Awake(){
		if (manager == null)
			manager = this;
		else
			Debug.Log ("HAHAHHAHAHA");
		
	}

	void Start (){
		foreach (GameObject player in manager.players) {
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

		won(winner.GetComponent<Player>());
	}
		
	public static float getScoreRequired(){
		return ( (GameManage2) Manager.manager).nbScoreRequired;
	}

	public static void won(Player p){
		//TODO
	}
}
