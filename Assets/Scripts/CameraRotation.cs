using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour {

public Transform PlayerTransform;
public float RotationSpeed = 5.0f;
private Vector3 _cameraOffset;

[Range(0.01f, 1.0f)]
public float SmoothFactor = 0.5f;
public bool LookAtPlayer = false;
public bool RotateAroundPlayer = true;

    private void Start(){
        _cameraOffset = transform.position - PlayerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate(){
        if (RotateAroundPlayer) {
          Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);
          _cameraOffset = camTurnAngle * _cameraOffset;
        }

        Vector3 newPos = PlayerTransform.position + _cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
        
        if (LookAtPlayer || RotateAroundPlayer) {
            transform.LookAt(PlayerTransform);
        }
    }
}
