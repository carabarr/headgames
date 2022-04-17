using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillBehavior : MonoBehaviour
{

    //public float speed;

    //Moves this GameObject 2 units a second in the forward direction
    void Update()
    {
        //transform.Translate(Vector3.back * Time.deltaTime * speed);
    }

    //Upon collision with another GameObject, this GameObject will reverse direction
    private void OnTriggerEnter(Collider other)
    {
        //speed = speed * -1;
        Destroy(gameObject);
        Debug.Log("Ball Collided with StarPiece");
    }


}
