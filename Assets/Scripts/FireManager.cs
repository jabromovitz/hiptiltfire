using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireManager : MonoBehaviour {

	public Transform fire;
	private Flamable fireScript;
	public Transform floor;
	private static float CENTER_ZONE_CUSHION = 20.0f;
	private Queue<Vector3> firePosQ = new Queue<Vector3>();

	void Start () {

		fireScript = fire.GetComponent<Flamable>();
		fireScript.onFlameExtinguished += onFireExtenguised;
		Init(4, 4);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Init (int zones, int repsPerZone) {

		// Populate fire position queue
		
		for (int i = 1; i <= zones; i++) {

			float increment = (1 - 0.01f * CENTER_ZONE_CUSHION/2) / (zones * 2);
			float pos = 0.01f * CENTER_ZONE_CUSHION/2 + (2 * i - 1) * increment;

			for (int j = 0; j < repsPerZone; j++) {

				firePosQ.Enqueue(new Vector3(0, 0, -1.0f * pos * 5f));
				firePosQ.Enqueue(new Vector3(0, 0, 1.0f * pos * 5f));
			}
		}
		
		// Set first fire
		SetNextFire();
		
		
	}

	private void SetNextFire() {

		fireScript.Reset();
		fire.localPosition = firePosQ.Dequeue();
	}

	private bool isFireQEmpty () {
		
		return firePosQ.Count == 0;
	}

	private void onFireExtenguised () {
		Debug.Log("Fire's out");
		if (!isFireQEmpty()) {
			
			SetNextFire();
		}
		
	}
}
