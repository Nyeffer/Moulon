using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    private GameObject target;
    private bool isActive = false;
    private bool stillActive = false;

    public GameObject bullet;
    public int fps = 1;
    public float counter = 0.0f;

    void Update() {
        
    }
    void OnTriggerEnter(Collider col) {
        
    }



    void OnTriggerExit(Collider col) {
       
    }
}
