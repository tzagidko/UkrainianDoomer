using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;
    [SerializeField] float smoothSpeed=0.1f;
    public Vector3 offset;
    void FixedUpdate(){
        Vector3 nextPos= target.position+offset;
        Vector3 smoothedPos= Vector3.Lerp(transform.position, nextPos, smoothSpeed);
        transform.position=smoothedPos;
    }
}
