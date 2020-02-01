using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    private bool isActive = false;
    private bool stillActive = false;
    private int tier = 0;
    public GameObject explosion;
    public GameObject nuzzle;
    public GameObject bullet;
    public GameObject[] BulletSpawners;
    public int fps = 1;
    public float counter = 0.0f;

    void Update() {
        if(isActive) {
            if(counter >= 60.0f/fps) {
                Instantiate(explosion,nuzzle.transform.position,nuzzle.transform.rotation);
                counter = 0.0f;
                isActive = false;
            } else {
                counter += Time.deltaTime;
            }
        }
        
    }
    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Player") {
            isActive = true;
        }
    }



    void OnTriggerExit(Collider col) {
       
    }
}
