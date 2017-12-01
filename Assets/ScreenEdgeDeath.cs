using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenEdgeDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Pixel>())
        {
			other.gameObject.GetComponent<Pixel> ().isDying = true;
            Debug.Log("A pixel is dying");
        }
    }

	private void OnTriggerExit(Collider other)
	{
		if(other.gameObject.GetComponent<Pixel>() && !other.gameObject.GetComponent<Pixel> ().isDead)
		{
			other.gameObject.GetComponent<Pixel> ().ResetDeathTimer ();
			Debug.Log("A pixel is alive");
		}
	}
}
