using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AttackScript : MonoBehaviour
{

    public int dmg;
    public float dmgspeed;
    public int knockback;
    public float kbradius;
    private float attack;
    private bool attackbool;
    private Vector3 kb;
    private Rigidbody rb;
    float cooldown;
    public Button b1;
    bool enemyexists, bossexists, playerexists;
    Animator anim;
    MovementController mc;
    public LayerMask m_attackable;
    BossControl bc;
    BossAttackRange ba;
    Collider[] attackableArray;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.transform.parent.parent.gameObject.GetComponent<Animator>();
        mc = transform.root.GetComponent<MovementController>();
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            bc = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossControl>();
            ba = GameObject.FindGameObjectWithTag("BossHitBox").GetComponent<BossAttackRange>();
        }
        cooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
    

    private void FixedUpdate()
    {
        enemyexists = false;
        bossexists = false;
        playerexists = false;
        if (gameObject.transform.parent.parent.gameObject.tag == "Player")
        {


            attack = Input.GetAxis("Fire1");
            if (attack > 0 && cooldown < Time.time)
            {
                //bc.GetIntoPosition();
                anim.SetTrigger("attack");
                cooldown = Time.time + dmgspeed;
                attackableArray = Physics.OverlapSphere(transform.position, kbradius, m_attackable);
                for (int i = 0; i < attackableArray.Length; i++) {
                    if (attackableArray[i].tag == "Enemy"){
                        enemyexists = true;
                    } else {
                        enemyexists = false;
                    }

                    if (attackableArray[i].tag == "Boss")
                    {
                        bossexists = true;
                    }
                    else
                    {
                        bossexists = false;
                    }
                }

                if (SceneManager.GetActiveScene().buildIndex == 2)
                {
                    for (int i = 0; i < attackableArray.Length; i++)
                    {
                        Debug.Log(attackableArray[i]);
                    }
                    if (enemyexists)
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
                }
                else
                {
                    if (!bc.GetShielded())
                    {
                        if (bossexists)
                        {
                            EnemyStats stats = attackableArray[0].GetComponent<EnemyStats>();
                            stats.subtractHealth(dmg);

                            if (attackableArray[0].gameObject.transform.position.x < transform.position.x)
                            {
                                kb = new Vector3(attackableArray[0].transform.position.x - transform.position.x, 0, 0).normalized;
                            }
                            else
                            {
                                kb = new Vector3(attackableArray[0].transform.position.x + transform.position.x, 0, 0).normalized;
                            }
                            kb *= knockback;
                            rb = attackableArray[0].transform.GetComponent<Rigidbody>();
                            rb.velocity = new Vector3(0, 0, 0);
                            rb.AddForce(kb, ForceMode.Impulse);
                        }
                    }
                }
            }
        } else if (gameObject.transform.parent.parent.gameObject.tag == "Boss")
        {
            if (!bc.GetShielded())
            {
                if (ba.GetAttackable() == true && cooldown < Time.time)
                {
                    //bc.GetIntoPosition();
                    anim.SetTrigger("attack");
                    cooldown = Time.time + dmgspeed;

                    attackableArray = Physics.OverlapSphere(transform.position, kbradius, m_attackable);
                    Debug.Log(attackableArray.Length);
                    if (attackableArray.Length > 0)
                    {
                        if (attackableArray[0].gameObject.tag == "Player")
                        {
                            PlayerStats stats = attackableArray[0].GetComponent<PlayerStats>();
                            stats.subtractHealth(dmg);

                            if (attackableArray[0].gameObject.transform.position.x < transform.position.x)
                            {
                                kb = new Vector3(attackableArray[0].transform.position.x - transform.position.x, 0, 0).normalized;
                            }
                            else
                            {
                                kb = new Vector3(attackableArray[0].transform.position.x + transform.position.x, 0, 0).normalized;
                            }
                            kb *= knockback;
                            rb = attackableArray[0].transform.GetComponent<Rigidbody>();
                            rb.velocity = new Vector3(0, 0, 0);
                            rb.AddForce(kb, ForceMode.Impulse);
                        }
                    }
                }
            }
        }
    }
}
