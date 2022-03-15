using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody rb;
    private float HorizontalInput;
    private float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        //rb.AddForce(Vector3.right);
        rb.AddForce(new Vector3(HorizontalInput, 0.0f, 0.0f) * speed);
    }

    
}
