using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotate : MonoBehaviour {

    public float m_speed;
    public bool x, y, z;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (x) {
            transform.Rotate(Time.deltaTime * m_speed, 0, 0);
        } else if (y)
        {
            transform.Rotate(0, Time.deltaTime * m_speed, 0);
        } else if (z)
        {
            transform.Rotate(0, 0, Time.deltaTime * m_speed);
        }
       
	}
}
