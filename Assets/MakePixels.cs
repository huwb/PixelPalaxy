using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePixels : MonoBehaviour
{
    public float _attractForce = 100f;
    public float _attractRadius = 2f;
    public float _charAttractForce = 1f;

    public float _pixelSize = 0.1f;

    public Transform _pixelPrefab;

    public List<Rigidbody> _pixels = new List<Rigidbody>();

	public int getPixelCount(){
		return _pixels.Count;
	}

	void Start ()
    {
        int N = 10;
        for( int i = 0; i < N; i++ )
        {
            for( int j = 0; j < N; j++ )
            {
                Transform inst = Instantiate( _pixelPrefab ) as Transform;
                float x = (i - N / 2) * _pixelSize;
                float y = (j - N / 2) * _pixelSize;
                inst.position = transform.position + new Vector3( x, y, 0f );
                float hue = 0.5f + Mathf.Atan2( y, x ) / (Mathf.PI * 2f);
                //Debug.Log( hue );
                inst.GetComponent<Renderer>().material.color = Random.ColorHSV( hue, hue, 0.9f, 1f, 0.5f, 0.6f );
                var rb = inst.GetComponent<Rigidbody>();
                rb.useGravity = false;
                //inst.parent = transform;
                _pixels.Add( inst.GetComponent<Rigidbody>() );
            }
        }
    }
	
	void FixedUpdate ()
    {
        Pixel.AttractPixelsTowardsRB( this, GetComponent<Rigidbody>(), false, _charAttractForce );
	}
}
