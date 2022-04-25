using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    GameObject player;
	CameraShake cameraShake;  
	ForwardMovement MoveSpeed;

	private float xValue;
	private float yValue;
	private float zValue;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
		cameraShake = GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>();
		MoveSpeed = GameObject.FindWithTag("Movement").GetComponent<ForwardMovement>();

		xValue = Random.Range(-45.0f, 45.0f);
		yValue = Random.Range(-45.0f, 45.0f);
		zValue = Random.Range(-45.0f, 45.0f);
		
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate (new Vector3 (xValue, yValue, zValue) * Time.deltaTime);
    }

     private void OnTriggerEnter(Collider other)
    {
        //speed = speed * -1;
        Destroy(gameObject);
        if (other.gameObject.name == "Spaceship") {

            //Debug.Log("collided with spaceship");
            player.GetComponent<NewShipDam>().TakeDamage(1);
			StartCoroutine(cameraShake.Shake(.15f, .15f));

			//SLOW THE PLAYER DOWN??? - emmeline 
			MoveSpeed.SetSpeed(1f);
			
        } 
    }
}
