using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : MonoBehaviour
{
		public Slider slider;
		public int fuel_value;
		
		//max health at the start of the game
		void Start(){

			SetMaxHealth(100f);

		}


		//Update depletes health gradually
		//TODO - refine + vary depletion rate
		void Update(){
			
			SetHealth(slider.value - .02f);
			
			if (slider.value <= 0)
			{
			Debug.Log("You died");
			//TODO: load end screen
			}
		}

		//pick up fuel+ add to current fuel level
		public void PickupHealth(int fuel_value)
		{
			float health = slider.value;

			if (health + fuel_value < slider.maxValue)
			{
				SetHealth(health + fuel_value);
			} else {
				SetMaxHealth(100);	
			}
		
		}

		public void SetMaxHealth(float health)
		{
			slider.maxValue = health;
			slider.value = health;

		}

		public void SetHealth(float health)
		{
			slider.value = health;
		}
}
