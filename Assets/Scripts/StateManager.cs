using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    public GameObject ready;
    public GameObject gCounters;
    public Text text;
    public EnemyManager enemyManager;
    public int lifeCount = 3;
    private int maxLife;
    private int killCount = 0;
    private bool isStarted = false; // the state before the enemy spawn timers starts

    void Start() {
        maxLife = lifeCount;
    }

    void Update() {
        if(enemyManager.GetEnemyNum() == killCount) {
            // Win
        }
        if(isStarted) {
            ready.SetActive(false);
            gCounters.SetActive(true);
            text.text = " " + lifeCount.ToString() + " / " + maxLife.ToString() + " ";
        } else {
            if(Input.GetButtonDown("Start")) {
                StartNow();
            }
        }
    }

    public void StartNow() {
        isStarted = true;
        enemyManager.SetStart(isStarted);
    }

    public void Reach() {
        lifeCount -= 1;
    }

    public void GotKilled() {
        killCount += 1;
    }

}
