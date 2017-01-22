using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject[] players;
    public GameObject[] spawners;
    public float respawnTime;
    public int nbKillRequired;
    public float m_time_end;
    public Text m_text;

    private float timer;
    private static GameManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Use this for initialization
    void Start () {
        timer = m_time_end;
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
            end();
        //m_text.text = String.Format("{0:0}:{1:00}", Mathf.Floor(timer / 60), timer % 60); 
	}

    void end()
    {
        GameObject winner = null;
        int nbKill = 0;
        foreach (GameObject gm in players)
        {
            if (gm.GetComponentInChildren<PlayerHead>().getNbKill() > nbKill)
            {
                nbKill = gm.GetComponentInChildren<PlayerHead>().getNbKill();
                winner = gm;
            }
        }

       // won(winner.GetComponent<Player>());
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

    public static int getNbKillRequired()
    {
        return instance.nbKillRequired;
    }

    public static void won(Player p)
    {
        //TODO fin de partie
    }

} 
