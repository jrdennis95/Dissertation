using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

    private float movement;
    public float m_speed;
    bool taunted, leftdirection;
    Animator anim;
    Rigidbody rb;
    private GameObject player;
    public GameObject bear, hitbox, bearbox;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        taunted = false;
        leftdirection = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider hit)
    {

    }

    private void OnTriggerExit(Collider hit)
    {
        taunted = false;
        anim.SetBool("taunted", taunted);
    }

    private void OnTriggerStay(Collider hit)
    {
        if (hit.gameObject.tag == "Player" && taunted == false)
        {
            taunted = true;
            anim.SetBool("taunted", taunted);
            player = hit.gameObject;
            if (player.transform.position.x < bear.transform.position.x)
            {
                leftdirection = true;
            }
            else if (player.transform.position.x > bear.transform.position.x)
            {
                leftdirection = false;
            }
        }
    }

    public bool getDirection()
    {
        return leftdirection;
    }

    private void FixedUpdate()
    {
        if (taunted)
        {

            Vector3 tempscale = bear.transform.localScale;
            Vector3 tempposition = hitbox.transform.localPosition;
            Vector3 tempbox = bearbox.transform.localScale;
            if (leftdirection)
            {
                tempscale.y = Mathf.Abs(bear.transform.localScale.y);
                bear.transform.localScale = tempscale;

                tempposition.z = Mathf.Abs(hitbox.transform.localPosition.z);
                hitbox.transform.localPosition = tempposition;

                tempbox.z = Mathf.Abs(bear.transform.localScale.z);
                bearbox.transform.localScale = tempbox;

                rb.velocity = new Vector3((m_speed * -1), rb.velocity.y, 0);
            }
            else if (leftdirection == false)
            {
                tempscale.y = Mathf.Abs(bear.transform.localScale.y) * -1;
                bear.transform.localScale = tempscale;

                tempposition.z = Mathf.Abs(hitbox.transform.localPosition.z) * -1;
                hitbox.transform.localPosition = tempposition;

                tempbox.z = Mathf.Abs(bear.transform.localScale.z) * -1;
                bearbox.transform.localScale = tempbox;

                rb.velocity = new Vector3(m_speed, rb.velocity.y, 0);
            }
        }
    }

    void Flip()
    {
        leftdirection = !leftdirection;
        Vector3 tempscale = bear.transform.localScale;
        tempscale.y *= -1;
        bear.transform.localScale = tempscale;
    }
}
