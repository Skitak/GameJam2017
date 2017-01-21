using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {

	public float changeSpeed = 1;
    public GameObject[] winds;
    private int activeWind;
    public float timer_from;
    public float timer_to;
    public float transition_time;
    public GameObject particles;

	private float timer_begin;
    private float timer;

	private Quaternion rotationOrigin;

    void Start()
    {
        changeDirection();
    }

	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
            changeDirection();

		//if (transform.rotation != winds [activeWind].transform.rotation)
		transform.rotation = Quaternion.Lerp (rotationOrigin, winds [activeWind].transform.localRotation, 1-(timer / timer_begin));
		//Debug.Log (timer / timer_begin);

	}

    private void changeDirection()
    {
        activeWind = Random.Range(0, winds.Length);
        timer = Random.Range(timer_from, timer_to);
		timer_begin = timer;
        //Sound & animation
		rotationOrigin = transform.rotation;

    }
}
