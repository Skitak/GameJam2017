using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Manager {

    public int nbKillRequired;
    public float m_time_end;
    public Text m_text;

    private float timer;

    void Awake()
    {
        if (Manager.manager == null)
			Manager.manager = this;
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

    

    public static int getNbKillRequired()
    {
		return ((GameManager)Manager.manager).nbKillRequired;
    }

    public static void won(Player p)
    {
        //TODO pls
    }

} 
