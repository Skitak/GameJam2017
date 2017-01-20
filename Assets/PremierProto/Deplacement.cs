using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour {

    public Transform myTransform; // mon Transform
    float myYrotate;
    Rigidbody myRigidbody;

    public GameObject Wind; // le gameObject Vent
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

    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody>();
        myTransform = gameObject.GetComponent<Transform>();
        Wind = GameObject.FindGameObjectWithTag("Wibd");
        windTransform = Wind.GetComponent<Transform>();

    }
	
	// Update is called once per frame
	void Update () {
        axe = Input.GetAxis("Horizontal" + this.name);
        transform.eulerAngles += new Vector3(0,  axe * 180 * Time.deltaTime * (vRotate-SpeedUpdate()/vMax),0) ;


        myYrotate = myTransform.rotation.y;
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
