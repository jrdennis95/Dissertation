using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollision : MonoBehaviour {

    private int collisionCount = 0;
    public float offset;
    private GameObject player;
    private GameObject[] enemy;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectsWithTag("Enemy");
	}

    // Update is called once per frame
    void Update() {

        if (player.transform.position.y > transform.position.y + offset) {
            Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        }
        else {
            Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        }

    }

    private void OnCollisionEnter(Collision hit)
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), hit.collider, true);
    }
}
