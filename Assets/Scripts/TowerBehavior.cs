using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    private bool isActive = false;
    private bool stillActive = false;
    private int tier = 0;
    private int FpsTier = 1;
    public GameObject explosion;
    public GameObject nuzzle;
    public GameObject bullet;
    public GameObject[] BulletSpawners;
    public float counter = 0.0f;

    void Update() {
        if(isActive) {
            if(counter >= Time.deltaTime/FpsTier) {
                Instantiate(explosion,nuzzle.transform.position,nuzzle.transform.rotation);
                for(int i = 0; i < tier; i++) {
                    BulletSpawners[i].GetComponent<BulletSpawn>().Spawn();
                }
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

    public void SetFpsTier() {
        FpsTier += 1;
    }
}
