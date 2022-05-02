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
    // range of 4 is the default that we've been using since the beginning
    public float range;

    float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = rate;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * Time.deltaTime * 3);
        
        if (transform.position.x <= -range) {
            dir = Vector3.right;
        } else if (transform.position.x >= range) {
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

    public void easierRange () {
        while (range > 2) {
            range = range - (Time.deltaTime * 0.1f);
        }

    }

    public void defaultRange () {
        Debug.Log("widening range again");
        while (range < 2) {
            range = range + (Time.deltaTime * 0.1f);
        }

    }
}
