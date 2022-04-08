using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody rb;
	private Animator ship_anim;
    private float HorizontalInput;
    private float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

		ship_anim = GetComponent<Animator>();
		ship_anim.SetBool("NoTurn", true);
		ship_anim.SetBool("LeftTurn", false);
		ship_anim.SetBool("RightTurn", false);
		
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

		//NOOB CODE FOR ANIMATION WOOOOOOOOOOO
		if (HorizontalInput > 0) 
		{
			ship_anim.SetBool("RightTurn", true);
			ship_anim.SetBool("LeftTurn", false);
			ship_anim.SetBool("NoTurn", false);
		}

		if (HorizontalInput < 0) 
		{
			ship_anim.SetBool("LeftTurn", true);
			ship_anim.SetBool("RightTurn", false);
			ship_anim.SetBool("NoTurn", false);
		}
		
		if (HorizontalInput == 0) 
		{
			ship_anim.SetBool("NoTurn", true);
			ship_anim.SetBool("RightTurn", false);
			ship_anim.SetBool("LeftTurn", false);
		}
		//Debug.Log(HorizontalInput);
    }
}
