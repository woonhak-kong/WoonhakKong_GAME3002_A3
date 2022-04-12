using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringArm : MonoBehaviour
{
    public Transform Target;

    public Vector3 OffsetFromTarget;

    public float LagFactor;

    private Vector3 _velocity = Vector3.zero;


    void LateUpdate()
    {
        if (Target != null)
        {
            Vector3 DestinationPosition = Target.position + OffsetFromTarget;
            //transform.position = Vector3.Lerp(transform.position, Destination,  Time.deltaTime);
            transform.position = Vector3.SmoothDamp(transform.position, DestinationPosition, ref _velocity, LagFactor);
        }
    }
}
