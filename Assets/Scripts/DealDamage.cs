using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public int damage = 10;
    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Enemy") {
            col.gameObject.GetComponent<EnemyHealth>().DealDamage(damage);
            Destroy(this.gameObject);
        }
    } 
}
