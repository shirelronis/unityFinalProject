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
		if(Input.GetKey("q"))
		{
			// playerFps.GetComponent<Rigidbody>().isKinematic = false;
			// boat.GetComponent<BoatScript>().enabled = true;
			mainCamera.SetActive(false);
			fpsCamera.SetActive(true);
			// playerFps.SetActive(false);
		}
		else
        {
			fpsCamera.SetActive(false);
			mainCamera.SetActive(true);
		}

		//Controll Fps
		if(Input.GetKey("2"))
		{
			// playerFps.GetComponent<Rigidbody>().isKinematic = true;
			// boat.GetComponent<BoatScript>().enabled = false;
			fpsCamera.SetActive(false);
			mainCamera.SetActive(true);
			// playerFps.SetActive(true); 
			// playerFps.transform.position = playerFpsStartPos.transform.position;
		}
	}
}