﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour {

    public Transform[] background;
    private float[] scale;
    public float smooth;
    private Vector3 position;

	// Use this for initialization
	void Start () {
        position = transform.position;
        scale = new float[background.Length];
        for(int i = 0; i < background.Length; i++)
        {
            scale[i] = Mathf.Abs(background[i].position.z) * -1;
        }
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < background.Length; i++)
        {
            float effect = (position.x - transform.position.x) * scale[i];
            //float jumpeffect = (position.y - transform.position.y) * scale[i];
            Vector3 overalltar = new Vector3(background[i].position.x + effect, background[i].position.y, background[i].position.z);

            background[i].position = Vector3.Lerp(background[i].position, overalltar, smooth * Time.deltaTime);
        }
        position = transform.position;
	}
}
