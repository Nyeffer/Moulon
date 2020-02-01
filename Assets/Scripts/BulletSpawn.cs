using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{
    private int bTier = 0;
    public GameObject[] bullets;



    public void Spawn() {
        Instantiate(bullets[bTier],gameObject.transform.position, Quaternion.identity);
    }

    public void SetBulletTier(int level) {
        bTier = level;
    }
}
