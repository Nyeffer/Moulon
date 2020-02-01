using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int MaxHp = 100;
    public int curHp = 0;

    public bool isDeftype = true;
    private bool isDead = false;

    void Start() {
        curHp = MaxHp;
    }

    public void DealDamage(int dam, bool myDeftype, bool Damtype) {
        if(myDeftype == Damtype) {
            curHp = curHp - (int)(dam * 0.5f);
            Debug.Log("Resist");
        } else {
            curHp = curHp - (int)(dam * 2.0f);
            Debug.Log("Effective");
        }
        Debug.Log(curHp);
    }

    void Update() {
        if(curHp <= 0) {
            isDead = true;
            Destroy(this.gameObject);
        }
    }

    public bool GetDefType() {
        return isDeftype;
    }

    public bool GetisDead() {
        return isDead;
    }
}
