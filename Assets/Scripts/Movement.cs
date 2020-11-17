using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Movement : NetworkBehaviour {

    public float playerSpeed = 8;
    private GameObject astronaut;
    private Rigidbody rigidBody;
    private bool isMoving;

    private void Start() {
        if (this.isLocalPlayer) {
            astronaut = this.gameObject.transform.Find("astronaut").gameObject;
            rigidBody = this.gameObject.GetComponent<Rigidbody>();
        }
    }
    void FixedUpdate()
    {
        if (this.isLocalPlayer) {
            float horizontalAxis = Input.GetAxisRaw("Horizontal");
            float verticalAxis = Input.GetAxisRaw("Vertical");

            //assuming we only using the single camera:
            var camera = Camera.main;

            //camera forward and right vectors:
            var forward = camera.transform.forward;
            var right = camera.transform.right;

            //project forward and right vectors on the horizontal plane (y = 0)
            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();

            var rotation = camera.transform.rotation;
            rotation.x = 0;
            rotation.z = 0;
            astronaut.transform.rotation = rotation;

            if (isMoving)
            {

                if (verticalAxis > 0)
                {
                    astronaut.transform.Rotate(0.0f, 0.0f, 0.0f, Space.Self);
                }
                else if (verticalAxis < 0)
                {
                    astronaut.transform.Rotate(0.0f, 180.0f, 0.0f, Space.Self);
                }
                else if (horizontalAxis < 0)
                {
                    astronaut.transform.Rotate(0.0f, -90.0f, 0.0f, Space.Self);
                }
                else if (horizontalAxis > 0)
                {
                    astronaut.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
                }
            }

            //this is the direction in the world space we want to move:
            var desiredMoveDirection = forward * verticalAxis + right * horizontalAxis;

            //now we can apply the movement:
            rigidBody.velocity = desiredMoveDirection * playerSpeed * Time.deltaTime * 100;
            isMoving = rigidBody.velocity.x != 0 || rigidBody.velocity.z != 0;
        }
    }

    void Update()
    {
        if (this.isLocalPlayer) {
            astronaut.GetComponent<Animator>().SetBool("Moving", isMoving);
        }
    }
}
