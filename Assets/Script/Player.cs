﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public void die()
    {
        Destroy(this.gameObject);
        Debug.Log("Ded");
    }

}
