using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackRange : MonoBehaviour {

    private bool m_attackable;
	// Use this for initialization
	void Start () {
        m_attackable = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            m_attackable = true;
        }
    }

    private void OnTriggerExit(Collider hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            m_attackable = false;
        }
    }

    public bool GetAttackable()
    {
        return m_attackable;
    }
}
