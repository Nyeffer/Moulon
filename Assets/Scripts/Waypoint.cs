using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    private int index;
   void OnTriggerEnter(Collider col) {
       if(col.gameObject.tag == "Enemy") {
           index = col.gameObject.GetComponent<EnemyMovement>().GetIndex();
           col.gameObject.GetComponent<EnemyMovement>().SetIndex(index + 1);

       }    
   }
}
