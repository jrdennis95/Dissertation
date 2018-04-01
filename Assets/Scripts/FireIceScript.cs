using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireIceScript : MonoBehaviour {

    public float m_speed;
    public int m_damage;
    public int m_heal;
    public float decay;
    private BossControl bc;
        // Use this for initialization
        void Start () {
            bc = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossControl>();
        }
	
	// Update is called once per frame
	void Update () {
        decay -= Time.deltaTime;
        if(decay <= 0)
        {
            Destroy(gameObject);
        }
        if (gameObject.tag == "Fire")
        {
            transform.position = new Vector3(transform.position.x - m_speed, transform.position.y, transform.position.z);
        } else if (gameObject.tag == "Ice")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - m_speed, transform.position.z);
        } else if (gameObject.tag == "Heart")
        {
            if (bc.GetFirePhase())
            {
                transform.position = new Vector3(transform.position.x - m_speed, transform.position.y, transform.position.z);
            } else if (bc.GetIcePhase())
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - m_speed, transform.position.z);
            }
        }
	}

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Heart") {
                hit.GetComponent<PlayerStats>().addHealth(m_heal);
                Destroy(gameObject);
            }
            else {
                hit.GetComponent<PlayerStats>().subtractHealth(m_damage);
                Destroy(gameObject);
            }
        }
    }
}
