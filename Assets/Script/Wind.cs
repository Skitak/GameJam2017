using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {

    public GameObject[] winds;
    private int activeWind;
    public float timer_from;
    public float timer_to;
    public float transition_time;

    private float timer;

    void Start()
    {
        changeDirection();
    }

	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
            changeDirection();
	}

    private void changeDirection()
    {
        activeWind = Random.Range(0, winds.Length);
        timer = Random.Range(timer_from, timer_to);
        //Sound & animation
        transform.rotation = winds[activeWind].transform.rotation;
    }
}
