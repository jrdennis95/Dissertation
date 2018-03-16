using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour {

    private PlayerStats stats;
	// Use this for initialization
	void Start () {
        stats = GetComponent<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Fish")
        {
            Destroy(hit.gameObject);
            stats.addScore(10);
        } else if (hit.gameObject.tag == "Coin")
        {
            Destroy(hit.gameObject);
            stats.addScore(2);
        } else if (hit.gameObject.tag == "Coin Stack")
        {
            Destroy(hit.gameObject);
            stats.addScore(12);
        }
    } 
}
