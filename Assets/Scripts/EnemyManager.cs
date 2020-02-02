using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public GameObject[] Enemies;
    public float[] timeTillSpawn;

    private float timeSince = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSince += Time.deltaTime;
    }

    void EnemyActive(int EnemyNum) {
        Enemies[EnemyNum].SetActive(true);
    }


}
