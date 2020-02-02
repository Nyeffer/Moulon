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
    private Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }
    
    void Update() {
        if(CanManage) {
            Debug.Log(canBlock);
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
                    anim.SetBool("isActive", true);
                    text.text = "Upgrade";
                }
            }
        }
        if(currentlyBlocking > BlockCount) {
            canBlock = false;
            anim.SetBool("isActive", false);
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

    void OnTriggerExit(Collider col) {
        if(col.gameObject.tag == "Player") {
            messages.SetActive(false);
            CanManage = false;
        }
       
    }

    public bool GetcanBlock() {
        return canBlock;
    }

    public void AddEnemy() {
        currentlyBlocking += 1;
    }
}
