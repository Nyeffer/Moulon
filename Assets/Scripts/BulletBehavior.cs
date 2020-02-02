using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public GameObject explosion;
    public float speed = 2.0f;

    void Update() {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Ground" || col.gameObject.tag == "Enemy") {
            Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
