using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{

    private GameObject target; // the game Object this object will seek
    private bool CanMove = false;

    public float speed = 2.0f; // How fast the bullet travels

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CanMove) {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
        }
    }

    public void SetTarget(GameObject myTarget) {
        target = myTarget;
    }

    public void SetCanMove(bool move) {
        CanMove = move;

    }
}
