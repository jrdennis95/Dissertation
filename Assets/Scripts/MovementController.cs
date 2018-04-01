using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoBehaviour {

    public float m_speed;
    public float m_jump;
    public LayerMask m_ground, m_platform;
    public Button b1, b2, b3;
    public Transform m_feet;
    Collider[] groundArray, platformArray;
    bool grounded = false;
    bool jumping = false;
    bool animationhold = false;
    private bool pressed;
    Animator anim;
    Rigidbody rb;
    private float movement;
    private float m_distance;
    private float timer;
    private Vector3 touchOrigin = -Vector2.one;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        pressed = false;
        jumping = false;
        timer = 0;
    }
	
	// Update is called once per frame

    
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, m_distance + 0.1f);
    }

    private void Update()
    {
        if (timer <= 0)
        {
            timer = 0;
        }
        else
        {
            timer -= Time.deltaTime;
        }

        float vertical = Input.GetAxis("Horizontal");

        if (Input.GetAxis("Jump") > 0){
            if(grounded && timer <= 0)
            {
                grounded = false;
                rb.AddForce(new Vector3(0, m_jump, 0));
            }
            timer = 0.1f;
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

        //movement = Input.GetAxis("Horizontal");
        anim.SetFloat("velocity", Mathf.Abs(vertical));
        rb.velocity = new Vector3(vertical * m_speed, rb.velocity.y, 0);
        Vector3 tempscale = transform.localScale;
        if (vertical > 0)
        {
            tempscale.z = Mathf.Abs(transform.localScale.z);
            transform.localScale = tempscale;
        }
        else if (vertical < 0)
        {
            tempscale.z = Mathf.Abs(transform.localScale.z) * -1;
            transform.localScale = tempscale;
        }

    }
}
