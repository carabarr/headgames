using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    // for left-right movement of spawner
    private Vector3 dir = Vector3.left;



    public GameObject spawnObject;
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
 
      if(transform.position.x <= -4){
           dir = Vector3.right;
      }else if(transform.position.x >= 4){
           dir = Vector3.left;
      }

      spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f)
            {
                Instantiate(spawnObject, transform.position, Quaternion.identity);
                
                spawnTimer = rate;
            }

    }
}
