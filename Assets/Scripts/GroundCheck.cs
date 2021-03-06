﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private bool isGrounded = false;
    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Ground") {
            isGrounded = true;
        }
    }
    
    void OnTriggerExit(Collider col) {
        if(col.gameObject.tag == "Ground") {
            isGrounded = false;
        }
    }
    
    public bool GetGroundCheck() {
        return isGrounded;
    }
}
