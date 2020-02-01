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
        Debug.Log(counter);
        if(isActive) {
            if(counter >= 60.0f/(float)fps) {
                counter = 0.0f;
                stillActive = true;
                if(stillActive) {
                    Instantiate(bullet);
                    bullet.GetComponent<BulletBehavior>().SetTarget(target);
                    bullet.GetComponent<BulletBehavior>().SetCanMove(true);
                    stillActive = false;
                }
            } else {
                counter += Time.deltaTime;
            }
        }
    }
    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Player") {
            target = col.gameObject;
            isActive = true;
        }
    }



    void OnTriggerExit(Collider col) {
        if(col.gameObject.tag == "Player") {
            target = null;
            isActive = false;
        }
    }
}
