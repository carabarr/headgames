using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovement : MonoBehaviour
{

    public float speed;
    private float ogSpeed;
	private float addScore;

    private Vector3 dir = Vector3.forward;


    // Start is called before the first frame update
    void Start()
    {
        ogSpeed = speed;
		FuelBar.fuelDepletion = 1;
		
    }


    // Update is called once per frame
    void Update()
    {

        // moves everything forward
        transform.Translate(dir * speed * Time.deltaTime);

        // score updater
		addScore = speed * Time.deltaTime;
		GameHandler.playerScore += addScore;
        
    }
}
