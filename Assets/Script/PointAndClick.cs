using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndClick : MonoBehaviour {

    Vector3 positionClick;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

    }

    /*
    RaycastHit hit;
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    if(Physics.Raycast(ray, out hit)) {
    positionClick = hit.point;
    //transform.position = positionClick;
    Debug.Log(positionClick);
    }
    }
    return positionClick = new Vector3(0,0,0);
    */
    /*
    void OnMouseUp() {
        if (Input.GetMouseButton(0))
        {

        }
            
    }
    */
    /*
     {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, 100))
            print("Hit something!");
    }
    */

    public void OnMouseDown()
    {
        print("down");
    }
}
