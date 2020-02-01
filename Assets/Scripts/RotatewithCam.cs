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

    void FixedUpdate(){
            //assuming we're only using the single camera:
                var camera = Camera.main;
           
                //Data recieved from CrossPlatformInput Handler:
                  float horizontalAxis = Input.GetAxis("Horizontal");
                  float verticalAxis = Input.GetAxis("Vertical");
               
            float facing = camera.transform.rotation.y;
            float DistanceFromNeutral = 0;
            float transformZ = 0;
            float transformX = 0;
            float finalZ = 0;
            float finalX = 0;
           
            if (facing > -90 && facing <= 90){ //facing forward
                if(facing >= 0){
                    DistanceFromNeutral = (90 - facing);
                }else{
                    if(facing < 0){
                        DistanceFromNeutral = (90 + facing);
                    };
                };
               
               
                transformX = (1 / 90) * (DistanceFromNeutral);
                transformZ = 90 - transformX;
            };
           
            //for monitoring and debugging:
            Debug.Log("Main Camera's <color=red>Y rotation</color> is <color=red>" + facing + "</color>, and the <color=blue>Distance from Neutral rotation</color> <color=purple>(0/90/180/270)</color> is <color=blue>" + DistanceFromNeutral + "</color>.");
           
            // continue
           
            finalX = (transformX * verticalAxis) + (transformZ * horizontalAxis);
           
            //if(finalX > 1){
            //    finalX = 1;
            //    };
            // ^^^^ dont use, causes vector3 slowdowns or something ^^^^
           
            finalZ = (transformZ * verticalAxis) + (transformX * horizontalAxis);
           
            //if(finalZ > 1){
            //    finalZ = 1;
            //    };
            // ^^^^ dont use, causes vector3 slowdowns or something ^^^^
           
            transform.Translate((new Vector3( finalX * 0.01f , 0f , finalZ * 0.01f ))* MoveSpeed * Time.deltaTime);
}
}