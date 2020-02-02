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

    public GameObject messages;
    public Text text;
    public GameObject explosion;
    public GameObject nuzzle;
    public GameObject[] bullets;
    public float counter = 0.0f;

    void Start() {
        anim = GetComponent<Animator>();
    }

    void Update() {
        if(CanManage) {
            if(isActive) {
                if(Input.GetButtonDown("Active/Upgrade")) {
                    Debug.Log(tier);
                    if(tier < 2) {
                        tier += 1;
                    } else {
                        tier = 2;
                    }
                }
            } else {
                if(Input.GetButtonDown("Active/Upgrade")) {
                    isActive = true;
                    anim.SetBool("isActive", true);
                    text.text = "Upgrade";
                }
            }
        }
        if(isActive) {
            if(counter >= 2 / FpsTier) {
                    Instantiate(explosion,nuzzle.transform.position,Quaternion.identity);
                    Instantiate(bullets[tier],nuzzle.transform.position,nuzzle.transform.rotation);
                    
                counter = 0.0f;
            } else {
                counter += Time.deltaTime;
            }
        }
        
    }
    
    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Player") {
            if(!isActive) {
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

    public void SetFpsTier() {
        FpsTier += 1;
    }
}
