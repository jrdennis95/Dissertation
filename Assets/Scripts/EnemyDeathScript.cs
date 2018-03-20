using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathScript : MonoBehaviour {

    float decay;
    // Use this for initialization
    void Start () {
        decay = 3.0f;
	}
	
	// Update is called once per frame
	void Update () {
        decay -= Time.deltaTime;

        if(decay < 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    private void OnCollisionEnter(Collision hit)
    {
        Debug.Log(hit.gameObject.tag);
        if (hit.gameObject.tag == "Player")
        {
            Debug.Log("hit");
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), hit.collider, true);
        }
        else
        {
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), hit.collider, false);
        }
    }

}
