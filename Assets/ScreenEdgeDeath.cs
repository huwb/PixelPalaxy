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
            other.gameObject.SetActive(false);
            Debug.Log("A pixel died");
        }
    }
}
