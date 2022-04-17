using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FuelBar : MonoBehaviour {

      public float startHealth = 100;
      private float health;
      public Image healthBar;
      public Color healthyColor = new Color(0.3f, 0.8f, 0.3f);
      public Color unhealthyColor = new Color(0.8f, 0.3f, 0.3f);

      private void Start () {
            health = startHealth;
      }

		//Update depletes health gradually
		//TODO - refine + vary depletion rate
		void Update(){
			TakeDamage(.2f);
		}

      public void SetColor(Color newColor){
            healthBar.GetComponent<Image>().color = newColor;
      }


      public void TakeDamage (float amount){
            health -= amount;
            healthBar.fillAmount = health / startHealth;
            //turn red at low health:
            if (health < 0.3f){
                  if ((health * 100f) % 3 <= 0){
                        SetColor(Color.white);
                        Die();
                  }
                  else {
                        SetColor(unhealthyColor);
                  }
            }
            else {
                  SetColor(healthyColor);
            }
      }



      public void Die(){
            Debug.Log("YOU LOSE UR DEAD LOLOLOL");
           // TODO: death effect + load losing screen
            //Vector3 objPos = this.transform.position
            //Instantiate(deathEffect, objPos, Quaternion.identity) as GameObject;
            //SceneManager.LoadScene ("NAME OF LOSE SCENE");
      }
}