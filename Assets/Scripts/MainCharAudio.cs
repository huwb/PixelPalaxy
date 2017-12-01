using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharAudio : MonoBehaviour {
	public AudioSource spaceship;
	public Rigidbody ship;

	float speed = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float volLerp = Mathf.InverseLerp(0.5f, 3.75f, ship.velocity.magnitude);
		spaceship.volume = volLerp;
	}
}
