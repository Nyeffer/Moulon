using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private int waypointIndex = 0;
    private bool isBlocked = false;
    public Transform[] waypoints;
    public float moveSpeed = 5.0f;



    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if(!isBlocked) {
            Move();
        }
    }

    void Move() {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].position, moveSpeed * Time.deltaTime);
    }

    public int GetIndex() {
        return waypointIndex;
    }

    public void SetIndex(int newVal) {
        waypointIndex = newVal;
    }


    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Wall") {
            if(col.gameObject.GetComponent<WallBehaviour>().GetcanBlock()) {
                col.gameObject.GetComponent<WallBehaviour>().AddEnemy();
                isBlocked = true;
            }
        }
    }

    void OnTriggerExit(Collider col) {
        if(col.gameObject.tag == "Wall") {
            isBlocked = false;
        }

    }
}
