using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractFollow : MonoBehaviour {

    public GameObject E, speech, player;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        E.transform.position = player.transform.position + new Vector3(0, 1.8f, 0);
        speech.transform.position = player.transform.position + new Vector3(0.8f, 2.1f, 0);
    }
}
