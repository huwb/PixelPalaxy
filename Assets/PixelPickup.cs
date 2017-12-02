using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelPickup : MonoBehaviour {

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
            for(int i = 0; i < 25; i++)
            {
                GameObject newPx = (GameObject)Instantiate(other.gameObject);

                MakePixels mkPix = GameObject.Find("PlayerCharacter").GetComponent<MakePixels>();

                mkPix._pixels.Add(newPx.GetComponent<Rigidbody>());
            }
            

            Debug.Log("Got a pickup");
            this.gameObject.SetActive(false);
        }
    }
}
