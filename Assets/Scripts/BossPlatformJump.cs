using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlatformJump : MonoBehaviour {

    BossControl boss;
    public GameObject player;
    // Use this for initialization
    void Start () {
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossControl>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        

    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Boss")
        {
            if (gameObject.name != "JumpArea3")
            {
                Debug.Log("bloop");
                if (boss.GetNeedToJump())
                {
                    boss.Jump();
                }
            }
        }
    }

    private void OnTriggerStay(Collider hit)
    {
        if (gameObject.name == "JumpArea3")
        {
            if (boss != null)
            {
                if (player.transform.position.y > boss.transform.position.y + 1)
                {
                    boss.LargeJump();
                }
            }
        }
    }
}
