using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    // for left-right movement of spawner
    private Vector3 dir = Vector3.left;



    public GameObject starPiece;
    public GameObject asteroid;
    public Vector3 spawnPoint;
    public float rate;

    float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = rate;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir*Time.deltaTime*3);
        
        if (transform.position.x <= -4) {
            dir = Vector3.right;
        } else if (transform.position.x >= 4) {
            dir = Vector3.left;
        }
        
        spawnTimer -= Time.deltaTime;

        // create a random number that will decide if you spawn an asteroid
        // or a star piece
        int spawnDecider = Random.Range(1, 6);
        
        if (spawnTimer <= 0f) {

            if (spawnDecider < 2) {
                Instantiate(asteroid, transform.position, Quaternion.identity);
            } else {
                Instantiate(starPiece, transform.position, Quaternion.identity);
            }
            
            spawnTimer = rate;

        }

    }
}
