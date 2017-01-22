using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EasyF : MonoBehaviour {

    private GameObject ShipInMovement;

    void Start()
    {
        ShipInMovement = GetComponentInParent<ShipManager>().ShipInMovement;
    }

    void Update()
    {
        if (ShipManager.IsClick)
            ShipInMovement.transform.position =
                new Vector3(ShipInMovement.transform.position.x,
                    ShipInMovement.transform.position.y,
                        ShipInMovement.transform.position.z - 10f * Time.deltaTime);
    }

    public void RunEzF()
    {
        ShipManager.IsClick = true;
        Invoke("Toward", 3);
    }

    public void Toward()
    {
        SceneManager.LoadScene(1);
    }
}
