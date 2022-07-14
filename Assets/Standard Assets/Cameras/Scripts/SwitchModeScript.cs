using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchModeScript : MonoBehaviour {     // Empty GameObjectGameManager
	// public GameObject boat;
    public GameObject mainCamera;
	public GameObject fpsCamera;
	public GameObject playerFps;
	// public GameObject playerFpsStartPos;

	void Update () { 
		//Controll Shooting 
		if(Input.GetKey("s"))
		{
            // SET SHOOTING ENABLE
			// playerFps.GetComponent<Rigidbody>().isKinematic = false;
			// boat.GetComponent<BoatScript>().enabled = true;
			fpsCamera.SetActive(true);
            mainCamera.SetActive(false);
			// playerFps.SetActive(false);
		}

		//Controll Fps
		if(Input.GetKey("2"))
		{
            // SET SHOOTING DISABLE
			// playerFps.GetComponent<Rigidbody>().isKinematic = true;
			// boat.GetComponent<BoatScript>().enabled = false;
			fpsCamera.SetActive(false);
            mainCamera.SetActive(true);
			// playerFps.SetActive(true); 
			// playerFps.transform.position = playerFpsStartPos.transform.position;
		}
	}
}