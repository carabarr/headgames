using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardMovement : MonoBehaviour
{

    public float speed;
    private float ogSpeed;

    private Vector3 dir = Vector3.forward;


    // Start is called before the first frame update
    void Start()
    {
        ogSpeed = speed;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void restoreSpeed()
    {
        speed = ogSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(dir * speed);
        
    }
}
