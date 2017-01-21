using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void RunGame()
    {
        SceneManager.LoadScene(1); //remplacer 0 par l'index de la scène de jeu (Qui peut être modifiée dans le Build Settings)
    }
}
