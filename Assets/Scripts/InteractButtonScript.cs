using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButtonScript : MonoBehaviour {

    private GameObject interact1, interact2;
    private bool detected, opening, opened;
    private float timer;
    private float pos;
	// Use this for initialization
	void Start () {
        detected = false;
        opening = false;
        opened = false;
        pos = gameObject.transform.GetChild(1).transform.position.x;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime / 5;
        if (detected)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                timer = 0;
                opening = true;
            }
        }

        if (opening)
        {
            if (timer < 0.15f)
            {
                gameObject.transform.GetChild(1).transform.position = new Vector3(pos + timer, gameObject.transform.GetChild(1).transform.position.y, gameObject.transform.GetChild(1).transform.position.z);
            } else
            {
                opened = true;
            }
        }

        if (opened)
        {
            AudioSource audio;
            audio = GetComponent<AudioSource>();
            AudioSource.PlayClipAtPoint(audio.clip, transform.position);
            GameObject.FindGameObjectWithTag("Trapdoor").SetActive(false);
            gameObject.GetComponent<InteractButtonScript>().enabled = false;
        }
	}

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Player" && opened == false)
        {
            hit.transform.root.GetChild(0).gameObject.SetActive(true);
            detected = true;
        }
    }

    private void OnTriggerExit(Collider hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            hit.transform.root.GetChild(0).gameObject.SetActive(false);
            detected = false;
        }
    }
}
