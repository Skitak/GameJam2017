using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometeSpawner : MonoBehaviour {

    public GameObject comete;
    public float m_range_inf = 20;
    public float m_range_sup = 30;

    private float timer = 1;

	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = Random.Range(m_range_inf, m_range_sup);
            Instantiate(comete, this.transform.position, this.transform.rotation);
        }
	}
}
