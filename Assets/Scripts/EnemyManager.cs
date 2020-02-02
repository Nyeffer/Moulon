using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public GameObject[] Enemies;
    public float[] timeTillSpawn;
    private int enemySpawned = 0;
    private bool started = false;
    private bool finishSpawning = false;

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
       // if(started) {

            timeSince += Time.deltaTime;
              
            if(timeTillSpawn[enemySpawned] < timeSince) {
                if(enemySpawned >= (Enemies.Length - 1)) {
                    started = false;
                } else {
                    EnemyActive(enemySpawned);
                    enemySpawned += 1;
                }
            }
            
       // }
    }

    void EnemyActive(int EnemyNum) {
        Enemies[EnemyNum].SetActive(true);
    }


}
