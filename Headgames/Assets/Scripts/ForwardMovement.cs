using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovement : MonoBehaviour
{

    public float speed;
	public float acceleration;
    private float ogSpeed;
	private float maxSpeed = 13f;
	private float addScore;

    private Vector3 dir = Vector3.forward;


    // Start is called before the first frame update
    void Start()
    {
        ogSpeed = speed;
		FuelBar.fuelDepletion = 1;
		
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
	}

    public void restoreSpeed()
    {
        speed = ogSpeed;
		FuelBar.fuelDepletion = 1;

    }

    // Update is called once per frame
    void Update()
    {
			// speed += acceleration;

			// if (speed == maxSpeed/2){
			// 	Debug.Log("WE ARE ON ON DEPLETION LEVEL 2");
			// 	FuelBar.fuelDepletion = 2;
			// }
 
			// if (speed > (maxSpeed - 2)){
			// 	speed = maxSpeed;
			// 	FuelBar.fuelDepletion = 3;
			// }

        transform.Translate(dir * speed * Time.deltaTime);
		addScore = speed * Time.deltaTime;
		GameHandler.playerScore += addScore;
        
    }
}
