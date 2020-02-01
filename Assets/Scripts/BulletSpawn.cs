using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    private int tier = 1;
    private int bTier = 0;
    private float counter = 0.0f;
    public GameObject[] bullets;



    void Update() {
        if(counter >= Time.deltaTime/tier) {
            Instantiate(bullets[bTier],gameObject.transform.position, Quaternion.identity);
            counter = 0.0f;
        } else {
            counter += Time.deltaTime;
        }
    }
}
