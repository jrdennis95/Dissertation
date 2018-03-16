using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageScript : MonoBehaviour {

    public int dmg;
    public int dmgspeed;
    public int knockback;
    public int kbradius;
    private Vector3 kb;
    private Rigidbody rb;
    float cooldown;

    bool range = false;
    GameObject player;
    PlayerStats stats;
    // Use this for initialization
    void Start () {
        cooldown = Time.time;
        player = GameObject.FindGameObjectWithTag("Player");
        stats = player.GetComponent<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void FixedUpdate()
    {
        if (range)
        {
            Damage();
        }
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Player")
        {
            range = true;
        }
    }

    private void OnTriggerExit(Collider hit)
    {
        if (hit.tag == "Player")
        {
            range = false;
        }
    }

    void Damage()
    {
        if (cooldown <= Time.time)
        {
            stats.subtractHealth(dmg);
            cooldown = Time.time + dmgspeed;
            Knockback(player.transform, true);
            Debug.Log(stats.getHealth());
        }
    }

    void Knockback(Transform t, bool horizontal)
    {
        if(horizontal)
        {
            if(t.position.x < transform.position.x)
            {
                kb = new Vector3(t.position.x - transform.position.x, 0, 0).normalized;
            } else
            {
                kb = new Vector3(t.position.x + transform.position.x, 0, 0).normalized;
            }
        }else
        {
            kb = new Vector3(0, (t.position.y - transform.position.y), 0).normalized;
        }
        kb *= knockback;
        rb = t.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, 0);
        kb.y = 0.1f * knockback;
        Debug.Log("kb = " + kb);
        rb.AddForce(kb, ForceMode.Impulse);
    }
}
