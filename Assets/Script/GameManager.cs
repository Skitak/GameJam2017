using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject[] players;
    public GameObject[] spawners;
    public float respawnTime;

    private static GameManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static GameObject getBestSpawnPoint(GameObject playerOut)
    {
        //calcul de la moyenne des positions des autres joueurs
        Vector3 moyenne = Vector3.one;
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
    
} 
