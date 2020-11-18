using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerScript : NetworkBehaviour {

    //Player settings
    public float playerSpeed = 8;
    private GameObject astronaut;
    private Rigidbody rigidBody;
    private bool isMoving;

    private void Start() {
        
    }
    
    public override void OnStartLocalPlayer() {
        //function is only called for local player
        //Turns local player blue
        // GetComponent<MeshRenderer> ().material.color = Color.blue;
        //Player setup
        astronaut = gameObject.transform.Find("Player").gameObject.transform.Find("astronaut").gameObject;
        rigidBody = gameObject.GetComponent<Rigidbody>();

        //Other setup
        this.gameObject.transform.Find("Player").gameObject.transform.Find("mapPointer").gameObject.SetActive(true);
        this.gameObject.transform.Find("Player").gameObject.transform.Find("playerLight").gameObject.SetActive(true);
        this.gameObject.transform.Find("Player").gameObject.transform.Find("camera").gameObject.SetActive(true);
    }
    
    void Update() {
        animationUpdate();
    }
    void FixedUpdate() {
        if (this.isLocalPlayer) {
            movement();
        }
    }

    void movement()
    {
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");
            
        //camera forward and right vectors:
        var camera = Camera.main.transform;
        var forward = camera.forward;
        var right = camera.right;

        //project forward and right vectors on the horizontal plane (y = 0)
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        var rotation = camera.rotation;
        rotation.x = 0;
        rotation.z = 0;
        astronaut.transform.rotation = rotation;

        if (isMoving) {

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

    void animationUpdate() {
        astronaut.GetComponent<Animator>().SetBool("Moving", isMoving);
    }
}
