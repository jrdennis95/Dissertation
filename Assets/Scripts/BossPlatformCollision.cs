using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlatformCollision : MonoBehaviour {

    private int collisionCount = 0;
    public float offset;
    private GameObject boss;
    public GameObject topplatform;
    BossControl bc;
    Rigidbody rb;
    private GameObject[] enemy;
    private float timer;
    // Use this for initialization
    void Start () {
        boss = GameObject.FindGameObjectWithTag("Boss");
        bc = boss.gameObject.GetComponent<BossControl>();
        rb = boss.gameObject.GetComponent<Rigidbody>();
        timer = 0;
    }

    // Update is called once per frame
    void Update() {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = 0;
        }

        if (bc.GetFirePhase() || bc.GetIcePhase()) {
            if (bc.GetPhaseNo() == 1)
            {
                Physics.IgnoreCollision(GetComponent<Collider>(), boss.GetComponent<Collider>(), true);
            } else{
                if (boss.transform.position.y > transform.position.y + offset)
                {
                    Physics.IgnoreCollision(GetComponent<Collider>(), boss.GetComponent<Collider>(), false);
                }
                else if (boss.transform.position.y < transform.position.y + offset)
                {
                    Physics.IgnoreCollision(GetComponent<Collider>(), boss.GetComponent<Collider>(), true);
                }
            }
        } else
        {
            if (boss.transform.position.y > transform.position.y + offset)
            {
                if (!bc.GetNeedToFall())
                {
                    Physics.IgnoreCollision(GetComponent<Collider>(), boss.GetComponent<Collider>(), false);
                } else
                {
                    Physics.IgnoreCollision(GetComponent<Collider>(), boss.GetComponent<Collider>(), true);
                }
            }
            else if (boss.transform.position.y < transform.position.y + offset)
            {
                Physics.IgnoreCollision(GetComponent<Collider>(), boss.GetComponent<Collider>(), true);
            }
            else
            {
                Physics.IgnoreCollision(GetComponent<Collider>(), boss.GetComponent<Collider>(), true);
            }
        }
    }

    private void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Boss")
        {
            timer = 0.05f;
        }
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (boss.transform.position.y < transform.position.y + offset)
        {
            bc.SetSeeking(false);
        }
    }
}
