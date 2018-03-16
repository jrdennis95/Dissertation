using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    public float m_speed;
    public float m_jump;
    public LayerMask m_ground, m_platform;
    public Transform m_feet;
    Collider[] groundArray, platformArray;
    bool grounded = false;
    bool animationhold = false;
    private bool pressed;
    Animator anim;
    Rigidbody rb;
    private float movement;
    private float vertvelocity;
    private float m_distance;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        pressed = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, m_distance + 0.1f);
    }

    private void FixedUpdate()
    {
        vertvelocity = Input.GetAxis("Jump");
        if (Input.GetAxis("Jump") > 0 && grounded)
        {
            grounded = false;
            //anim.SetBool("grounded", grounded);
            //animationhold = true;
                rb.AddForce(new Vector3(0, m_jump, 0));
        }

        groundArray = Physics.OverlapSphere(m_feet.position, 0.2f, m_ground);
        platformArray = Physics.OverlapSphere(m_feet.position, 0.2f, m_platform);

        if (groundArray.Length > 0 || platformArray.Length > 0)
        {
            grounded = true;
        } else
        {
            grounded = false;
        }
        anim.SetBool("grounded", grounded);

        movement = Input.GetAxis("Horizontal");
        anim.SetFloat("vertvelocity", Mathf.Abs(vertvelocity));
        anim.SetFloat("velocity", Mathf.Abs(movement));
        rb.velocity = new Vector3(movement * m_speed, rb.velocity.y, 0);
        Vector3 tempscale = transform.localScale;
        if (movement > 0)
        {
            tempscale.z = Mathf.Abs(transform.localScale.z);
            transform.localScale = tempscale;
        } else if (movement < 0)
        {
            tempscale.z = Mathf.Abs(transform.localScale.z) * -1;
            transform.localScale = tempscale;
        }


    }
}
