﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHead : MonoBehaviour {

	private Deplacement dep;
	public float coefBoostSpeed;
	public float timerBoostSpeed;
	public float timerImmunity;
	public shieldAnim shield;
    public Text m_text;

	private float startTime = 0.0f;
	private bool isInvincible;
	private bool isFlagged;
	private GameObject fils;

	private float baseSpeed;
	private float baseRotation;
    private int nbKill = 0;

    private PlayerSound audio;

	// Use this for initialization
	void Start () {
		dep = GetComponentInParent<Deplacement> ();
		baseSpeed = dep.vMax;
		baseRotation = dep.vRotate;
        if (m_text != null)
            m_text.text = "0";

        audio = GetComponentInParent<PlayerSound>();
	}

	void Update () {

	}

    /*private void OnCollisionEnter(Collision other)
    {
        Debug.Log("done");
        if (other.gameObject.CompareTag("Player"))
            other.gameObject.GetComponentInParent<Player>().die();
        else
            GetComponentInParent<Player>().die();
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponentInParent<Player>().die();
            ++nbKill;
            if (m_text != null)
                m_text.text = nbKill.ToString();
            if (Manager.deathMatch() && nbKill > GameManager.getNbKillRequired())
                GameManager.won(GetComponentInParent<Player>());
            audio.OnHit();
        }
        else if (other.gameObject.CompareTag("Front"))
        {
            shield.show();
            GetComponentInParent<Player>().derive(other.gameObject);
            audio.OnHit();
        }
        else if (other.gameObject.CompareTag("Wall"))
        {
            GetComponentInParent<Player>().die();
            //transform.parent.forward *= -1;
        }
        else if (other.gameObject.CompareTag("Collectible"))
        {
            if (other.name == "collectibleVitesse")
            {
                Destroy(other.gameObject);
                dep.vMax = dep.vMax * coefBoostSpeed;
                dep.vRotate = dep.vRotate * coefBoostSpeed;
                Invoke("SpeedTimer", timerBoostSpeed);
            }
            else if (other.name == "collectibleInvincible")
            {
                Destroy(other.gameObject);
                isInvincible = true;
                Invoke("ImmunityTimer", timerImmunity);
            }
            else if (other.name == "flag")
            {
                if (other.transform.parent != null)
                    return;
                other.transform.SetParent(this.transform);
                other.transform.position = Vector3.zero;
                fils = other.gameObject;
                isFlagged = true;
                dep.vMax = dep.vMax * coefBoostSpeed;
                dep.vRotate = dep.vRotate * coefBoostSpeed;
            }

        }
        else if (other.gameObject.CompareTag("Comete"))
        {
            audio.OnHit();
            return;
        }
        else
            GetComponentInParent<Player>().die();
    }

    public int getNbKill()
    {
        return nbKill;
    }

    public bool getInvincible(){
		return isInvincible;
	}

	public bool getFlagged(){
		return (isFlagged);
	}

	public void setFlagged(bool b){
		isFlagged = b;
	}

	public GameObject getFils(){
		return(fils);
	}

	public void SpeedTimer()
	{
		dep.vMax = baseSpeed;
		dep.vRotate = baseRotation;
	}

	void ImmunityTimer()
	{
		isInvincible = false;
	}
}
