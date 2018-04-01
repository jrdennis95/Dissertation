using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpeechFollow : MonoBehaviour {

    public GameObject speech, boss;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (boss != null)
        {
            speech.transform.position = boss.transform.position + new Vector3(0.8f, 2.1f, 0);
        }
    }
}
