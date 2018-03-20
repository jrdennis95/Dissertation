using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorScript : MonoBehaviour {

    private float startPos;
    public float m_speed;
    private GameObject player;
    public float offset;

    // Use this for initialization
    void Start () {
        startPos = transform.position.y;
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, startPos + Mathf.PingPong(Time.time * m_speed, 5), transform.position.z);

        if (player.transform.position.y > transform.position.y + offset)
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        }
        else
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }
    }
}
