using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometeSpawner : MonoBehaviour {

    public GameObject comete;
    public float m_range_inf = 20;
    public float m_range_sup = 30;

    private LineRenderer line;
    private float timer = 0.5f;
    private void Start()
    {
        timer = Random.Range(m_range_inf, m_range_sup);
        line = GetComponent<LineRenderer>();
        
        line.enabled = false;
    }

 

	void Update () {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            line.SetPositions(new Vector3[] {
            this.transform.position,
            this.transform.position + this.transform.forward * 250,
             });
            line.enabled = true;
            timer = Random.Range(m_range_inf, m_range_sup);
            Instantiate(comete, this.transform.position, this.transform.rotation);
            Invoke("changeLineRenderer", 0.5f);
        }
	}

    void changeLineRenderer()
    {
        line.enabled = false;
    }
}
