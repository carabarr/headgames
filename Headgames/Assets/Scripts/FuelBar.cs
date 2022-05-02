using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FuelBar : MonoBehaviour {

	public static int fuelDepletion;
	public float startHealth = 100;
	private float health;
	public Image healthBar;

	private void Start () {
		health = startHealth;
		
		//i am using this for three distinct fueldepletion rates
		//this can be accessed in other scritps by typing FuelBar.fuelDepletion 
		fuelDepletion = 1;
	}

	//Update depletes health gradually
	//TODO - refine depletion rate
	void Update(){

		//slowest rate
		if (fuelDepletion == 1){
			TakeDamage(.05f);
		}
		//medium rate
		else if (fuelDepletion == 2){
			TakeDamage(.06f);
		}
		//FAST rate
		else{
			TakeDamage(.08f);
		}
	}

	// slowly decreases the fuel tank
	public void TakeDamage (float amount){
		health -= amount;
		healthBar.fillAmount = health / startHealth;
		//turn red at low health:
		if (health < 0.3f) {
			if ((health * 100f) % 3 <= 0) {
				Die();
			} 
		}
	}

	// colliding with star pieces increases the fuel tank
	public void RefillTank (float starPieceHealth) {
		
		Debug.Log("REFILL TANK CALLED");
		if (health < startHealth) {
			health += starPieceHealth;

			if (health > startHealth){
				health = startHealth;
			}

			healthBar.fillAmount = health / startHealth;
		}
		
	}

	public void Die(){
		//Debug.Log("YOU LOSE UR DEAD LOLOLOL");
		// TODO: death effect + load losing screen
		//Vector3 objPos = this.transform.position
		//Instantiate(deathEffect, objPos, Quaternion.identity) as GameObject;
		SceneManager.LoadScene ("GameOver");
	}
}