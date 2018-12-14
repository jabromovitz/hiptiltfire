using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Flamable : MonoBehaviour {
     
     public float fireHealth = 50;
     public float maxFireHealth = 50;
     public float healthRegen = 5;
     public bool isOnFire = true;
     //Defining Delegate
    public event Action onFlameExtinguished;

    
    public void Reset() {

        fireHealth = maxFireHealth;
        isOnFire = true;
    }
     void OnParticleCollision(GameObject other) {       
         if(isOnFire) {
             fireHealth -= 1.0f;
             if (fireHealth <= 0) {
                isOnFire = false;
                onFlameExtinguished();
                //gameObject.SetActive(false);
             }
         }
     }

     void Update() {
         if (isOnFire) {
             fireHealth += Time.deltaTime * healthRegen;    
             if (fireHealth > maxFireHealth) {
                 fireHealth = maxFireHealth;
             }
         }
     }
 }

