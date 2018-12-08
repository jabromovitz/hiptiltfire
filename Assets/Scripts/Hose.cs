using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hose : MonoBehaviour {
	private float angleLimit = 75.0f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//Rotate hose
		float rot = Input.GetAxis("Tilt") * angleLimit;
        transform.rotation = Quaternion.Euler(0,0,rot);
	}
}
