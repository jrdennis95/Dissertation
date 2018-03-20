using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformCollision : MonoBehaviour {

    private int collisionCount = 0;
    public float offset;
    private GameObject player, boss;
    private GameObject[] enemy;
    private Button b1;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}

    // Update is called once per frame
    void TaskOnClick()
    {
        Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>(), true);
    }

    void Update() {


        if (player.transform.position.y > transform.position.y + offset) {
            Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        } else if (player.transform.position.y < transform.position.y + offset)
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>(), true);
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
        if (hit.gameObject.tag != "Boss")
            Physics.IgnoreCollision(GetComponent<Collider>(), hit.collider, true);
    }
}
