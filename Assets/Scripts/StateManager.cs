using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public GameObject messages;
    public EnemyManager enemyManager;
    private bool isStarted = false; // the state before the enemy spawn timers starts

    void Update() {

    }

    public void StartNow() {
        isStarted = true;
    }

}
