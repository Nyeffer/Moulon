using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int MaxHp = 100;
    private int curHp = 0;

    void Start() {
        curHp = MaxHp;
    }

    public void DealDamage(int dam) {
        curHp -= dam;
        Debug.Log(curHp);
    }

    void Update() {
        if(curHp <= 0) {
            Destroy(this.gameObject);
        }
    }
}
