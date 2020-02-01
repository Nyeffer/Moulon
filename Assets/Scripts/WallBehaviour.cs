using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallBehaviour : MonoBehaviour
{
    public int BlockCount = 2;
    public GameObject messages;
    public Text text;


    private int currentlyBlocking = 0;
    private bool canBlock = false;

    private bool CanManage = false;
    
    void Update() {
        if(CanManage) {
            if(canBlock) {
                if(Input.GetButtonDown("Active/Upgrade")) {
                    if(BlockCount < 4) {
                        BlockCount += 1;
                    } else {
                        BlockCount = 4;
                    }
                }
            } else {
                if(Input.GetButtonDown("Active/Upgrade")) {
                    canBlock = true;
                    text.text = "Upgrade";
                }
            }
        }
        if(currentlyBlocking > BlockCount) {
            canBlock = false;
            currentlyBlocking = 0;
        }
    }

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Player") {
            if(!canBlock) {
                messages.SetActive(true);
                CanManage = true;
            } else {
                messages.SetActive(true);
            }
        }
    }

    public bool GetcanBlock() {
        return canBlock;
    }

    public void AddEnemy() {
        currentlyBlocking += 1;
    }
}
