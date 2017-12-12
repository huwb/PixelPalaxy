using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float _force = 1f;
    public float _ConstantUpForce;

    Rigidbody _rb;


    void Start ()
    {
        _rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate ()
    {
        //_rb.AddForce( _force * Vector3.right * Input.GetAxis( "Horizontal" ), ForceMode.Impulse );
        //_rb.AddForce( _force * Vector3.up * Input.GetAxis( "Vertical" ), ForceMode.Impulse );

        Vector3 MouseWorldPosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        MouseWorldPosition.z = 0f;
        transform.position = MouseWorldPosition;

        //_rb.MovePosition( Vector3.Lerp( _rb.position, MouseWorldPosition, 5.0f * Time.fixedDeltaTime ) );

            
        _rb.AddForce(_ConstantUpForce * Vector3.up, ForceMode.Impulse);
    }
}
