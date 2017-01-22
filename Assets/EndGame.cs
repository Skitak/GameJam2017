using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

	void Update () {
        if (Input.GetButton("Submit"))
            SceneManager.LoadScene(0);
	}
}
