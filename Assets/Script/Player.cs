using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public void die()
    {
        Destroy(this.gameObject);
    }

    public void derive(GameObject other)
    {
        float difference,myY,hisY;
        myY = this.transform.eulerAngles.y;
        hisY = other.transform.eulerAngles.y;
        if (myY < hisY)
            difference = other.transform.eulerAngles.y - this.transform.eulerAngles.y;
        else
        {
            difference = this.transform.eulerAngles.y - other.transform.eulerAngles.y;
        }
        transform.eulerAngles += new Vector3(0, difference / 2, 0);        

    }

}
