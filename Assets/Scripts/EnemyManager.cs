using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public GameObject[] Enemies;
    public float[] timeTillSpawn;
    private int enemySpawned = 0;
    private bool started = false;

    private float timeSince = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < Enemies.Length; i++) {
            Enemies[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(started) {
            timeSince += Time.deltaTime;
            if(timeTillSpawn[enemySpawned] >= timeSince) {
                EnemyActive(enemySpawned);
            }
            if(enemySpawned >= Enemies.Length) {
                started = false;
            }
        }
    }

    void EnemyActive(int EnemyNum) {
        Enemies[EnemyNum].SetActive(true);
        enemySpawned += 1;
    }


}
