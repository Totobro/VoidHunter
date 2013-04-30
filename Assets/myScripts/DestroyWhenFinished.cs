using UnityEngine;
using System.Collections;

public class DestroyWhenFinished : MonoBehaviour {
	public ParticleSystem	system;
	
	// Use this for initialization
	void Start () {
		system = gameObject.GetComponent("ParticleSystem") as ParticleSystem;
	}
	
	// Update is called once per frame
	void Update () {
		if (system.isStopped)
			Destroy(gameObject);
	}
}
