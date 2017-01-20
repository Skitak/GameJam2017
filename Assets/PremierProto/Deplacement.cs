using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour {

    float myYrotate;
    Rigidbody myRigidbody;
    private string input; 
    public GameObject Wind;
    public int m_numJoueur;
    Transform windTransform; //le Transform du vent
    float yWind; // le y en rotation du wind

    float temp;
    float yMin;
    float yMax;

    public float vMax;
    public float vRotate;

    [Range(1.0f, 2.0f)]
    public  float rangeOfSpeed;

    float axe;
    
    void Start () {
        myRigidbody = GetComponent<Rigidbody>();
        Wind = GameObject.FindGameObjectWithTag("Wibd");
        windTransform = Wind.GetComponent<Transform>();
        input = "Horizontal " + m_numJoueur;
    }
	
	void Update () {
        axe = Input.GetAxis(input);
        transform.eulerAngles += new Vector3(0,  axe * 180 * Time.deltaTime * (vRotate-SpeedUpdate()/vMax),0) ;


        myYrotate = transform.rotation.y;
        yWind = windTransform.rotation.y;
        transform.position += (transform.forward * SpeedUpdate()) * Time.deltaTime;

        GizmosService.Cone(transform.position, transform.forward, transform.up, 5.0f, 25.0f);

    }

    float SpeedUpdate()
    {
        if ((myYrotate - yWind) < 0)
        {
            yMax = yWind;
            yMin = myYrotate;
        }
        else
        {
            yMax = myYrotate;
            yMin = yWind;
        }
        temp = yMax - yMin;
        return (Mathf.Abs(vMax - (vMax * (Mathf.Pow(temp,rangeOfSpeed)))));
    }
}
