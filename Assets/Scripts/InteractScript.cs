using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractScript : MonoBehaviour {

    private bool detected, decaying;
    private GameObject player;
    private float decay;
	// Use this for initialization
	void Start () {
        detected = false;
        decay = 2.0f;
    }
	
	// Update is called once per frame
	void Update () {
        if (detected)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                DisplaySpeech();
            }
        }

        if (decaying)
        {
            decay -= Time.deltaTime;

            if (decay < 0)
            {
                HideSpeech();
                decaying = false;
            }
        }
	}

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            player = hit.gameObject;
            hit.transform.root.GetChild(0).gameObject.SetActive(true);
            //DisplaySpeech(hit);
            detected = true;
        }
    }

    private void OnTriggerExit(Collider hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            player = hit.gameObject;
            hit.transform.root.GetChild(0).gameObject.SetActive(false);
            //HideSpeech(hit);
            detected = false;
        }
    }

    private void DisplaySpeech()
    {
        AudioSource audio;
        audio = GetComponent<AudioSource>();
        AudioSource.PlayClipAtPoint(audio.clip, player.transform.position);
        decay = 5.0f;
        decaying = true;
        player.transform.root.GetChild(0).gameObject.SetActive(false);
        player.transform.root.GetChild(1).GetChild(0).gameObject.SetActive(true);
        for(int i = 0; i < 8; i++)
        {
            if(gameObject.name == player.transform.root.GetChild(1).GetChild(i).gameObject.name)
            {
                player.transform.root.GetChild(1).GetChild(i).gameObject.SetActive(true);
                decay = 2.0f;
                decaying = true;
            }
        }
    }

    private void HideSpeech()
    {
        for (int i = 0; i < 8; i++)
        {
            if (gameObject.name == player.transform.root.GetChild(1).GetChild(i).gameObject.name)
            {
                player.transform.root.GetChild(1).GetChild(0).gameObject.SetActive(false);
                player.transform.root.GetChild(1).GetChild(i).gameObject.SetActive(false);
            }
        }
    }

}
