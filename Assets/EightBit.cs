using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EightBit : MonoBehaviour {

    public Material _pixelTheShitMat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnRenderImage( RenderTexture source, RenderTexture destination )
    {
        Graphics.Blit( source, destination, _pixelTheShitMat );
    }
}
