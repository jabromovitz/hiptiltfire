using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Flamable : MonoBehaviour {
     
     ParticleSystem flame;
     ParticleSystem smoke;
     private float smokeDuration;
     public float fireHealth = 50;
     public float maxFireHealth = 50;
     public float healthRegen = 5;
     public bool isOnFire = true;
     //Defining Delegate
    public event Action onFlameExtinguished;

    
    void Start()
    {
        // Assign fire and smoke particle systems
        foreach(Transform child in transform) {
            
            if(child.tag == "flame")
                flame = child.GetComponent<ParticleSystem>();
            else if (child.tag == "smoke") {
                smoke = child.GetComponent<ParticleSystem>();
                smokeDuration = smoke.main.duration + smoke.main.startLifetimeMultiplier;
            }
        }
    }
    public void Reset() {

        smoke.Stop();
        flame.Play();
        fireHealth = maxFireHealth;
        isOnFire = true;
    }
     void OnParticleCollision(GameObject other) {
             
         if(isOnFire) {
             fireHealth -= 1.0f;
             if (fireHealth <= 0) {
                isOnFire = false;
                StartCoroutine(WaitForSmokeToClear());
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

      IEnumerator WaitForSmokeToClear()
    {

        yield return new WaitForSeconds(smokeDuration);
        onFlameExtinguished();
    }
 }

