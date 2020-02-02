using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBehavior : MonoBehaviour
{
    private bool CanManage = false;
    private bool isActive = false;
    private bool stillActive = false;
    private int tier = 0;
    private int FpsTier = 1;
    private Animator anim;
    private GameObject player;

    public GameObject messages;
    public Text text;
    public GameObject explosion;
    public GameObject nuzzle;
    public GameObject[] bullets;
    public int cost = 100;
    public float counter = 0.0f;

    void Start() {
        anim = GetComponent<Animator>();
    }

    void Update() {
        if(CanManage) {
            if(isActive) {
                text.text = " " + (cost).ToString() +  " - Upgrade";
                if(Input.GetButtonDown("Active/Upgrade")) {
                    Debug.Log(tier);
                    if(tier < 2) {
                        player.GetComponent<RotatewithCam>().Buy(cost);
                        cost = (int)(cost * 2.5f);
                        text.text = " " + (cost).ToString() +  " - Upgrade";
                        tier += 1;
                    } else {
                        text.text = "MAX";
                        tier = 2;
                    }
                    
                }
            } else {
                text.text = " " + cost.ToString() + " - Active";
                if(Input.GetButtonDown("Active/Upgrade")) {
                    isActive = true;
                    anim.SetBool("isActive", true);
                    player.GetComponent<RotatewithCam>().Buy(cost);
                    cost = (int)(cost * 2.5f);
                    text.text = " " + (cost).ToString() +  " - Upgrade";
                }
            }
        }
        if(isActive) {
            if(counter >= 2 / FpsTier) {
                    Instantiate(explosion,nuzzle.transform.position,nuzzle.transform.rotation);
                    Instantiate(bullets[tier],nuzzle.transform.position,nuzzle.transform.rotation);
                    
                counter = 0.0f;
            } else {
                counter += Time.deltaTime;
            }
        }
        
    }
    
    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Player") {
            player = col.gameObject;
            if(!isActive) {
                messages.SetActive(true);
                if(col.gameObject.GetComponent<RotatewithCam>().GetCurrency() < cost) {
                    text.text = "Not enough Resources";
                } else {
                    CanManage = true;
                }
            } else {
                messages.SetActive(true);
                if(col.gameObject.GetComponent<RotatewithCam>().GetCurrency() < cost) {
                    text.text = "Not enough Resources";
                } else {
                    CanManage = true;
                }
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

    public void SetFpsTier() {
        FpsTier += 1;
    }
}
