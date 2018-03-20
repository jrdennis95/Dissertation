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
            AudioSource audio;
            audio = hit.gameObject.GetComponent<AudioSource>();
            Destroy(hit.gameObject);
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            stats.addScore(2);
        } else if (hit.gameObject.tag == "Coin Stack")
        {
            AudioSource audio;
            audio = hit.gameObject.GetComponent<AudioSource>();
            Destroy(hit.gameObject);
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            stats.addScore(12);
        }
    } 
}
