using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallBehaviour : MonoBehaviour
{
    public int BlockCount = 2;
    public GameObject messages;
    public Text text;
    public int cost = 100;


    private GameObject player;
    private int currentlyBlocking = 0;
    private bool canBlock = false;

    private bool CanManage = false;
    private Animator anim;

    private GameObject[] Enemies;

    void Start() {
        anim = GetComponent<Animator>();
        Enemies = new GameObject[BlockCount];
    }
    
    void Update() {
        Debug.Log(currentlyBlocking);
        if(currentlyBlocking > 0) {
            for(int i = 0; i < currentlyBlocking; i++) {
                if(Enemies[i] == null) {
                    currentlyBlocking -= 1;
                }
            }
        }
        if(CanManage) {
            Debug.Log(canBlock);
            if(canBlock) {
                if(Input.GetButtonDown("Active/Upgrade")) {
                    if(BlockCount < 4) {
                        player.GetComponent<RotatewithCam>().Buy(cost);
                        cost = (int)(cost * 2.5f);
                        text.text = " " + (cost).ToString() +  " - Upgrade";
                        BlockCount += 1;
                        Enemies = new GameObject[BlockCount];
                    } else {
                        text.text = "MAX";
                        BlockCount = 4;
                    }
                }
            } else {
                if(Input.GetButtonDown("Active/Upgrade")) {
                    canBlock = true;
                    anim.SetBool("isActive", true);
                    player.GetComponent<RotatewithCam>().Buy(cost);
                    cost = (int)(cost * 2.5f);
                    text.text = " " + (cost).ToString() +  " - Upgrade";
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
            player = col.gameObject;
            if(!canBlock) {
                messages.SetActive(true);
                if(col.gameObject.GetComponent<RotatewithCam>().GetCurrency() < cost) {
                    text.text = "Not enough Resources";
                } else {
                    CanManage = true;
                }
            } else {
                messages.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider col) {
        if(col.gameObject.tag == "Player") {
            player = null;
            messages.SetActive(false);
            CanManage = false;
        }
    }

    public bool GetcanBlock() {
        return canBlock;
    }

    public void AddEnemy(int num, GameObject enemy) {
        for(int i = 0; i < Enemies.Length; i++) {
            if(Enemies[i] == null) {
                Enemies[i] = enemy;
                currentlyBlocking += num;
            }
        }
    }
}
