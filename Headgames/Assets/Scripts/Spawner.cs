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

    // default asteroid/star spawn rate, should be 2 for a range of [1, 6]
    // less than 4 [1, 12]
    public int defaultRate;
    public int spawnRate;

    float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        spawnRate = defaultRate;
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
        int spawnDecider = Random.Range(1, 12);
        
        if (spawnTimer <= 0f) {

            if (spawnDecider < spawnRate) {
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
        while (range < 4) {
            range = range + (Time.deltaTime * 1f);
        }

    }

    public void lessAsteroids () {
        StartCoroutine(decreaseAsts());
    }

    IEnumerator decreaseAsts() {
        spawnRate = 1;
        yield return new WaitForSeconds(10);
        spawnRate = defaultRate;
    }
}
