using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float _force = 1f;

    Rigidbody _rb;

    void Start ()
    {
        _rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
    {
        _rb.AddForce( _force * Vector3.right * Input.GetAxis( "Horizontal" ), ForceMode.Impulse );
        _rb.AddForce( _force * Vector3.up * Input.GetAxis( "Vertical" ), ForceMode.Impulse );
	}
}
