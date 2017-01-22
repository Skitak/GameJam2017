using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {

	public float changeSpeed = 1;
    public GameObject[] winds;
    private int activeWind = 0;
    public float timer_from;
    public float timer_to;
    public float transition_time = 2;
    public GameObject particles;
	public bool paused;

	private float timer_begin;
    private float timer = 0;

	private Quaternion rotationOrigin;

    public float feedbackTimeBeforeWindChange = 2;

    public float feedbackDuration = 3;

    public GameObject windFeedbackGo;

    private Coroutine windChangeRoutine = null;

    void Start()
    {

        windFeedbackGo.GetComponentInChildren<MeshRenderer>().enabled = false;

        activeWind = Random.Range(0, winds.Length);
        timer = Random.Range(timer_from, timer_to);
        timer_begin = timer;
        rotationOrigin = transform.rotation;


    }

	void Update () {

		if (paused)
			return;


        timer -= Time.deltaTime;

        if (timer <= feedbackTimeBeforeWindChange && windChangeRoutine == null && windFeedbackGo != null)
        {
            windChangeRoutine = StartCoroutine("WindChange");
           
        }

	    
		transform.rotation = Quaternion.Lerp (rotationOrigin, winds [activeWind].transform.localRotation, (timer_begin - timer) / 2);

    }

    


    IEnumerator WindChange() {


        int nextActiveWind = Random.Range(0, winds.Length);

        windFeedbackGo.transform.position = new Vector3(Mathf.Sin(winds[nextActiveWind].transform.localEulerAngles.y * Mathf.Deg2Rad), 0, Mathf.Cos(winds[nextActiveWind].transform.localEulerAngles.y * Mathf.Deg2Rad)) * 100;
        windFeedbackGo.transform.forward = windFeedbackGo.transform.position;
        if (nextActiveWind != activeWind)
            windFeedbackGo.GetComponentInChildren<MeshRenderer>().enabled = true;


        yield return new WaitForSeconds(feedbackTimeBeforeWindChange);


        activeWind = nextActiveWind;
        timer = Random.Range(timer_from, timer_to);
        timer_begin = timer;
        //Sound & animation
        rotationOrigin = transform.rotation;



        yield return new WaitForSeconds(feedbackDuration - feedbackTimeBeforeWindChange);

        
        windFeedbackGo.GetComponentInChildren<MeshRenderer>().enabled = false;

        windChangeRoutine = null;

        
    }


}
