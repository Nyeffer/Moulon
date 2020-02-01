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

    public GameObject messages;
    public Text text;
    public GameObject explosion;
    public GameObject nuzzle;
    public GameObject bullet;
    public float counter = 0.0f;

    void Update() {
        if(CanManage) {
            if(isActive) {
                


            } else {
                if(Input.GetButtonDown("Active/Upgrade")) {
                    Debug.Log(isActive);
                    isActive = true;
                }
            }
        }
        if(isActive) {
            if(counter >= 2 / FpsTier) {
                    Instantiate(explosion,nuzzle.transform.position,nuzzle.transform.rotation);
                    Instantiate(bullet,nuzzle.transform.position,nuzzle.transform.rotation);
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
                text.text = "Upgrade";
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
