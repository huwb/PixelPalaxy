using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float _force = 1f;
    public float _ConstantUpForce;

    Rigidbody _rb;

    FixedCameraScroll _camera;

    void Start ()
    {
        _rb = GetComponent<Rigidbody>();
        _camera = FindObjectOfType<Camera>().GetComponent<FixedCameraScroll>();
	}

	void FixedUpdate ()
    {
        _rb.AddForce( _force * Vector3.right * Input.GetAxis( "Horizontal" ), ForceMode.Impulse );
        _rb.AddForce( _force * Vector3.up * Input.GetAxis( "Vertical" ), ForceMode.Impulse );

        _rb.AddForce(_ConstantUpForce * Vector3.up, ForceMode.Impulse);
    }
}
