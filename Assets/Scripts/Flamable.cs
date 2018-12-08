using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Flamable : MonoBehaviour {
     
     public float FireHealth = 50;
     public float MaxFireHealth = 50;
     public float HealthRegen = 5;
     public bool IsOnFire = true;
     
     void OnParticleCollision(GameObject other) {       
         if(IsOnFire) {
             FireHealth -= 1.0f;
             if (FireHealth <= 0) {
                 IsOnFire = false;
                 gameObject.SetActive(false);
             }
         }
     }

     void Update() {
         if (IsOnFire) {
             FireHealth += Time.deltaTime * HealthRegen;    
             if (FireHealth > MaxFireHealth) {
                 FireHealth = MaxFireHealth;
             }
         }
     }
 }

