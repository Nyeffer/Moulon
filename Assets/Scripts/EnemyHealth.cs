using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int MaxHp = 100;
    public int curHp = 0;

    public bool isDeftype = true;
    private bool isDead = false;
    public GameObject[] Money;

    void Start() {
        curHp = MaxHp;
    }

    public void DealDamage(int dam, bool myDeftype, bool Damtype) {
        if(myDeftype == Damtype) {
            curHp = curHp - (int)(dam * 0.5f);
        } else {
            curHp = curHp - (int)(dam * 2.0f);
        }
    }

    void Update() {
        if(curHp <= 0) {
            GetComponent<EnemyMovement>().sm.GotKilled();
            int rand = Random.Range(0, Money.Length);
            Instantiate(Money[rand], gameObject.transform.position, Quaternion.identity);
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
