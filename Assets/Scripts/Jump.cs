using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public GroundCheck groundCheck;
    public float jumpforce = 10.0f;
    private bool isGrounded = true;
    void Update() {
        isGrounded = groundCheck.GetGroundCheck();
        if(isGrounded) {
                if(Input.GetKeyDown("space")) {
                Debug.Log("Jump");
                gameObject.GetComponent<Rigidbody>().AddForce(0.0f, jumpforce, 0.0f);
            }
        }
    }
}
