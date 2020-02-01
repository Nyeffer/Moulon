using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private int waypointIndex = 0;
    private bool isBlocked = false;
    private float counter = 0.0f;
    public Transform[] waypoints;
    public float moveSpeed = 5.0f;
    public float dam = 10.0f;
    public int AtkSpeed = 1;



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
        Debug.Log(waypointIndex);
    }

    public int GetIndex() {
        return waypointIndex;
    }

    public void SetIndex(int newVal) {
        waypointIndex = newVal;
    }

    public float GetDam() {
        return dam;
    }

    public int GetAtkSpeed() {
        return AtkSpeed;
    }

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Wall") {
            if(col.gameObject.GetComponent<WallBehaviour>().GetBlockCount() > col.gameObject.GetComponent<WallBehaviour>().GetEnemyBlocked()) {
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
