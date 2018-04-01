using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDeathScript : MonoBehaviour {

    float decay;
    public bool boss;
    // Use this for initialization
    void Start () {
        decay = 3.0f;
	}
	
	// Update is called once per frame
	void Update () {
        decay -= Time.deltaTime;

        if(decay < 0)
        {
            Destroy(transform.parent.gameObject);
            if (boss)
            {
                SceneManager.LoadScene(8);
            }
        }
    }

    private void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag == "Player")
        {
            Debug.Log("hit");
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), hit.collider, true);
        }
        else
        {
            Physics.IgnoreCollision(gameObject.GetComponent<Collider>(), hit.collider, false);
        }
    }

}
