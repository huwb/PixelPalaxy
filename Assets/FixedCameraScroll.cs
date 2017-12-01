using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FixedCameraScroll : MonoBehaviour {
    private float mSpeed = 0f;
    public float _MaxScrollSpeed = 10f;
    public float _InitialAcceleration = 5f;

    public float GetSpeed()
    {
        return mSpeed;
    }

    public Vector2 _ScrollDirection = new Vector3(0,-1);

	// Use this for initialization
	void Start () {
        _ScrollDirection.Normalize();
	}
	
	// Update is called once per frame
	void Update () {
		if(mSpeed < _MaxScrollSpeed)
        {
            mSpeed += _InitialAcceleration * Time.deltaTime;
        }

        transform.Translate(_ScrollDirection * (mSpeed * Time.deltaTime));
	}
}
