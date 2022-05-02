using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillBehavior : MonoBehaviour
{
    
	public GameObject ps;
	GameObject particleSpawn;
	GameObject fbar;
    GameObject wall;

    void Start()
    {
        fbar = GameObject.FindWithTag("FuelBar");
		particleSpawn = GameObject.FindWithTag("SpawnParticles");
        wall = GameObject.FindWithTag("Wall");
    }


    void Update()
    {
		//SPINS
		transform.Rotate (new Vector3 (0.0f, 45.0f, 0.0f) * Time.deltaTime);
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
            fbar.GetComponent<FuelBar>().RefillTank(7f);
            wall.GetComponent<WallHit>().resetStars();
			Instantiate(ps, particleSpawn.transform.position, Quaternion.identity);

        } else {
            wall.GetComponent<WallHit>().missedStarsRow();

        }

        //Debug.Log(other.gameObject.name + " Collided with StarPiece");
    }


}
