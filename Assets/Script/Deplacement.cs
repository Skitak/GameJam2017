using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour {
    
    public GameObject Wind;
    public int m_numJoueur;

    public float vMax;
    public float vRotate;

    [Range(1.0f, 2.0f)]
    public  float rangeOfSpeed;

    float yWind;
    float yMin;
    float yMax;
    float myYrotate;
    float axe;
    float temp;

    Transform windTransform;
    Rigidbody myRigidbody;
    Vector3 joystickAxis;

    private string horizontalAxis;
    private string verticalAxis;
    
    void Start () {
        myRigidbody = GetComponent<Rigidbody>();
        joystickAxis = new Vector3(0, 0, 0);
        Wind = GameObject.FindGameObjectWithTag("Wibd");
        windTransform = Wind.GetComponent<Transform>();
        horizontalAxis = "Horizontal " + m_numJoueur;
        verticalAxis = "Vertical " + m_numJoueur;
    }
	
	void Update () {
        Rotate();
        


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

    private void Rotate()
    {
        joystickAxis.x = Input.GetAxis(horizontalAxis);
        joystickAxis.z = Input.GetAxis(verticalAxis);

        if (joystickAxis == Vector3.zero)
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
        }

        
        transform.eulerAngles += new Vector3(0, direction * 180 * Time.deltaTime * (vRotate - SpeedUpdate() / vMax), 0);
    }
}
