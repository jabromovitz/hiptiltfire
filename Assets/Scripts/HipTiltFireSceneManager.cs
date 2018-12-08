using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipTiltFireSceneManager : MonoBehaviour {

	public Transform floor;
	private Transform fire;
	private Vector3 fireOrigLocation;

	// Use this for initialization
	void Start () {
		
		// Get Fire
 		foreach (Transform child in transform) {
             if (child.CompareTag ("fire")) {
                 fire = child;
				 fireOrigLocation = fire.transform.position;

        	}
		 }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Spawn fire along central line of floor
	private void spawnFireAtLocation (float loc) {


		fire.position = new Vector3(fireOrigLocation.x, fireOrigLocation.y, loc);
	}
}
