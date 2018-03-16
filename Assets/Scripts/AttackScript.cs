using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {

    public int dmg;
    public float dmgspeed;
    public int knockback;
    public float kbradius;
    private float attack;
    private Vector3 kb;
    private Rigidbody rb;
    float cooldown;

    Animator anim;
    MovementController mc;
    public LayerMask m_attackable;
    Collider[] attackableArray;

    // Use this for initialization
    void Start () {
        anim = transform.root.GetComponent<Animator>();
        mc = transform.root.GetComponent<MovementController>();
        cooldown = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        attack = Input.GetAxis("Fire1");

        if (attack > 0 && cooldown < Time.time)
        {
            anim.SetTrigger("attack");
            cooldown = Time.time + dmgspeed;

            attackableArray = Physics.OverlapSphere(transform.position, kbradius, m_attackable);

            if (attackableArray.Length > 1)
            {
                if(attackableArray[0].gameObject.tag == "Enemy" && attackableArray[1].gameObject.tag != "Enemy" || attackableArray[0].gameObject.tag != "Enemy" && attackableArray[1].gameObject.tag == "Enemy")
                {
                    EnemyStats stats = attackableArray[0].transform.parent.gameObject.GetComponent<EnemyStats>();
                    stats.subtractHealth(dmg);

                    if (attackableArray[0].gameObject.transform.position.x < transform.position.x)
                    {
                        kb = new Vector3(attackableArray[0].transform.parent.gameObject.transform.position.x - transform.position.x, 0, 0).normalized;
                    }
                    else
                    {
                        kb = new Vector3(attackableArray[0].transform.parent.gameObject.transform.position.x + transform.position.x, 0, 0).normalized;
                    }
                    kb *= knockback;
                    rb = attackableArray[0].transform.parent.gameObject.transform.GetComponent<Rigidbody>();
                    rb.velocity = new Vector3(0, 0, 0);
                    rb.AddForce(kb, ForceMode.Impulse);
                }
                else
                {
                    Debug.Log("No");
                }
            }
            else
            {
                Debug.Log("No");
            }
        }
    }
}
