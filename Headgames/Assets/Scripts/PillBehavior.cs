using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillBehavior : MonoBehaviour
{

    //fuelLevel = GameObject.FindWithTag("FuelBar");
    //fBar = fuelLevel.GetComponent<FuelBar>();



    void Update()
    {

    }


    // COLLISION BEHAVIOR //
    // Upon colliding with anything, the starpiece will be destroyed
    //  - colliding with spaceship will cause fuel to go down
    private void OnTriggerEnter(Collider other)
    {
        //speed = speed * -1;
        Destroy(gameObject);

        if (other.gameObject.name == "Spaceship") {
            Debug.Log("collided with spaceship");
            //fbar.RefillTank(0.1f);

        } else {
            Debug.Log("collided with wall");

        }

        //Debug.Log(other.gameObject.name + " Collided with StarPiece");
    }


}
