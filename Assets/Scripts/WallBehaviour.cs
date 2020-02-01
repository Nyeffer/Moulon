using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehaviour : MonoBehaviour
{
    private float curHp = 0.0f;
    public int MaxHp = 100;
    public int BlockCount = 0;
    private float[] counters;


    // Start is called before the first frame update
    void Start()
    {
        curHp = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage() {


    }


}
