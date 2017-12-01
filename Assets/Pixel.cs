using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pixel : MonoBehaviour
{
    MakePixels _mp;
    FixedCameraScroll _camera;

    private void Start()
    {
        _mp = FindObjectOfType<MakePixels>();

        _camera = FindObjectOfType<Camera>().GetComponent<FixedCameraScroll>();
    }

    void OnDisable()
    {
        print("script was removed");
        _mp._pixels.Remove(GetComponent<Rigidbody>());
    }

    void FixedUpdate()
    {

        Rigidbody rb = GetComponent<Rigidbody>();
        AttractPixelsTowardsRB( _mp, rb, true, _mp._attractForce );

        //// Force us to follow the camera
        //transform.Translate(_camera.GetSpeed() * _camera._ScrollDirection * Time.deltaTime);

    }

    public static void AttractPixelsTowardsRB( MakePixels mp, Rigidbody attractTo, bool useRad, float force )
    {
        float rmax = mp._attractRadius * mp._pixelSize;
        foreach( Rigidbody rb in mp._pixels )
        {
            if( rb == attractTo ) continue;

            Vector3 offset = (attractTo.transform.position - rb.transform.position);
            float l2 = offset.sqrMagnitude;
            if( (useRad && l2 > rmax * rmax) )
                continue;
            if( l2 <= Mathf.Epsilon )
                continue;

            l2 = Mathf.Sqrt( l2 );
            offset /= l2;

            rb.AddForce( offset * force, ForceMode.Impulse );
            attractTo.AddForce( -offset * force, ForceMode.Impulse );
        }
    }
}
