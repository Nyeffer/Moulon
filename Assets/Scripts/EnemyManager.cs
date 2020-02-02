using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public Text text;
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
        text.text = " " + enemySpawned.ToString() + " / " + Enemies.Length.ToString() + " ";
        if(started) {
            timeSince += Time.deltaTime;
            if(timeTillSpawn[enemySpawned] < timeSince) {
                if(enemySpawned >= (Enemies.Length - 1)) {
                    started = false;
                } else {
                    EnemyActive(enemySpawned);
                    enemySpawned += 1;
                }
            }
       }
    }

    void EnemyActive(int EnemyNum) {
        Enemies[EnemyNum].SetActive(true);
    }

    public void SetStart(bool begin) {
        started = begin;
    }

    public int GetEnemyNum() {
        return Enemies.Length;
    }
}
