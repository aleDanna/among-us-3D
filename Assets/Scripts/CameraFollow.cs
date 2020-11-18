using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float RotationSpeed = 5.0f;
    public Vector3 _cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    private void Start(){
        _cameraOffset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate(){ 
        Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);
        _cameraOffset = camTurnAngle * _cameraOffset;

        Vector3 newPos = target.position + _cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
        
        transform.LookAt(target);
    }
}