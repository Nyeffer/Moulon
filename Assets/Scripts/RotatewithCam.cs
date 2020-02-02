using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotatewithCam : MonoBehaviour
{
    // Public Variables
    public float speedX = 2.0f;
    public float speedY = 2.0f;

    public float MoveSpeed = 2.0f;
    public Text money;

    // Private Variables

    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private int currency = 0;




    void Update() {
        money.text = currency.ToString();
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

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Currency") {
            // Do currency stuff
        }
    }

    public int GetCurrency() {
        return currency;
    }
}