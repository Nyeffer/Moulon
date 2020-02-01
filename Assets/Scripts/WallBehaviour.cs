using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehaviour : MonoBehaviour
{
    private float curHp = 0.0f;
    public int MaxHp = 100;
    private int BlockCount = 0;
    private int currentlyBlocking = 0;
    private int blockIndex = 0;

    private float[] counters;
    private GameObject[] Enemies;


    // Start is called before the first frame update
    void Start()
    {
        curHp = MaxHp;
        float[] counters = new float[BlockCount];
        GameObject[] Enemies = new GameObject[BlockCount];
    }

    // Update is called once per frame
    void Update() {
        if(blockIndex > BlockCount) {
            blockIndex = BlockCount;
        }
        for(int i = 0; i < Enemies.Length; i++) {
            if(Enemies[i] != null) {
                if(Enemies[i].GetComponent<EnemyHealth>().GetisDead()) {
                    Enemies[i] = null;
                } else {
                    if(counters[i] >= (Enemies[i].GetComponent<EnemyMovement>().GetAtkSpeed() * 5) * Time.deltaTime) {
                        TakeDamage(Enemies[i].GetComponent<EnemyMovement>().GetDam());
                        counters[i] = 0.0f; 
                    } else {
                        counters[i] += Time.deltaTime;
                    }
                }
            }
        }
    }

    void TakeDamage(float dam) {
        curHp -= dam;
    }

    void Upgrade() {
        BlockCount += 1;
        float[] counters = new float[BlockCount];
        GameObject[] Enemies = new GameObject[BlockCount];
    }

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Enemy") {
            if(Enemies[blockIndex] == null) {
                Enemies[blockIndex] = col.gameObject;
                blockIndex += 1;
            }
        }
    }

    public int GetBlockCount() {
        return BlockCount;
    }

    public int GetEnemyBlocked() {
        return currentlyBlocking;
    }

    public void AddEnemy() {
        currentlyBlocking += 1;
    }



}
