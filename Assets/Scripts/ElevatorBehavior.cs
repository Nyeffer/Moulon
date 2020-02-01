using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorBehavior : MonoBehaviour
{
    public GameObject destination;
    public GameObject origin;
    private bool isTravel = false;

    void Update() {
        if(isTravel) {
            gameObject.transform.Translate(destination.transform.position,Space.World);
        } else {
            gameObject.transform.Translate(origin.transform.position,Space.World);
        }
    }
    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Player") {
            isTravel = true;
            Debug.Log("StepOn");
            col.gameObject.transform.parent = transform;
        }
    }

    void OnTriggerExit(Collider col) {
        if(col.gameObject.tag == "Player") {
            isTravel = false;
            Debug.Log("StepOff");
			col.gameObject.transform.parent = null;
        }
    }
}
