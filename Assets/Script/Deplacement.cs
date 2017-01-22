using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour {
    
    
    public int m_numJoueur;

    public float vMax;
    public float vRotate;

    [Range(1.0f, 2.0f)]
    public  float rangeOfSpeed;
    public ParticleSystem particules;

    float yWind;
    float yMin;
    float yMax;
    float myYrotate;
    float axe;
    float temp;
    bool moved = false;

    Transform windTransform;
    Rigidbody myRigidbody;
    Vector3 joystickAxis;
    GameObject wind;

    private string horizontalAxis;
    
    void Start () {
        wind = GameObject.FindGameObjectWithTag("Wind");
        myRigidbody = GetComponent<Rigidbody>();
        joystickAxis = new Vector3(0, 0, 0);
        horizontalAxis = "Horizontal " + m_numJoueur;
    }
	
	void Update () {
        if (moved)
        {
            Rotate();

            yWind = wind.transform.eulerAngles.y;
            myYrotate = transform.eulerAngles.y;
            myRigidbody.velocity = transform.forward * SpeedUpdate();
        }
        else if (Input.GetAxis(horizontalAxis) != 0)
        {
            moved = true;
            particules.gameObject.SetActive(true);
            particules.Play();
        }

        //GizmosService.Cone(transform.position, transform.forward, transform.up, 5.0f, 25.0f);

    }

    public float SpeedUpdate()
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

		if (temp > 180)
			temp = 360 - temp;

		//Debug.Log (temp);
        return (Mathf.Abs(vMax - (vMax * (Mathf.Pow(temp/180,rangeOfSpeed)))));
    }

    private void Rotate()
    {
        joystickAxis.x = Input.GetAxis(horizontalAxis);

        /*if (joystickAxis == Vector3.zero)
            return;

        float angleDesired = Vector3.Angle(Vector3.forward, joystickAxis);
        if (joystickAxis.x < 0)
        {
            float diff = 180 - angleDesired;
            angleDesired += diff * 2;
        }
        Vector3 actualAxis = transform.eulerAngles;
        float actualAngle = transform.eulerAngles.y;

        float res;
        float direction;
        if (angleDesired - actualAngle < 2f && angleDesired - actualAngle > -2f)
            return;
        if (angleDesired > actualAngle)
        {
            res = angleDesired - actualAngle;
            direction = res > 180 ? -1 : 1;
        }
        else
        {
            res = actualAngle - angleDesired;
            direction = res > 180 ? 1 : -1;
        }*/

        float direction = Input.GetAxis(horizontalAxis);
        transform.eulerAngles += new Vector3(0, direction * 180 * Time.deltaTime * (vRotate - SpeedUpdate() / vMax), 0);
       // Debug.Log(actualAngle + " " + angleDesired);
    }
}
