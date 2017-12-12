using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour {

	public MakePixels pixelCreationScript;
    public GameplayManager gameplayManager;
	public CanvasRenderer HealthText;

	Text health;


	// Use this for initialization
	void Start () {
		if (!HealthText)
			return;
		
		health = HealthText.GetComponent<Text> ();
		health.text = "NINJA";
	}
	
	// Update is called once per frame
	void Update () {

		health.text = "HEALTH: " + pixelCreationScript.getPixelCount ().ToString ();
        health.text += "\t\tSCORE: " + gameplayManager.GetScore().ToString();
    }
}
