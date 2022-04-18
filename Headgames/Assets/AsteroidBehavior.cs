using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    GameObject player;

    void Start()
    {
         player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnTriggerEnter(Collider other)
    {
        //speed = speed * -1;
        Destroy(gameObject);
        if (other.gameObject.name == "Spaceship") {

            Debug.Log("collided with spaceship");
            player.GetComponent<NewShipDam>().TakeDamage(1);
        } else {
            Debug.Log("collided with wall");

        }
    }
}
