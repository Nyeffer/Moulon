using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatewithCam : MonoBehaviour
{
    // Public Variables
    public float speedX = 2.0f;
    public float speedY = 2.0f;

    public float MoveSpeed = 2.0f;

    // Private Variables

    private float yaw = 0.0f;
    private float pitch = 0.0f;



    void Update() {
         yaw += speedX * Input.GetAxis("Mouse X");
         transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }

    void FixedUpdate()  {
        //reading the input:
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
         
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
 
        //this is the direction in the world space we want to move:
        var desiredMoveDirection = forward * verticalAxis + right * horizontalAxis;
 
        //now we can apply the movement:
        transform.Translate(desiredMoveDirection * MoveSpeed * Time.deltaTime);
    }
}