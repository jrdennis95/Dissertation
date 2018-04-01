using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFireIceSpawner : MonoBehaviour {

    public GameObject Fire, Ice, Heart;
    private BossControl bc;
    public float cooldown;
    private float cooldown2;
    private float counter;
    Vector3[] leftarray, downarray;

    // Use this for initialization
    void Start () {
        counter = 0;
        cooldown2 = cooldown;
        bc = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossControl>();
        leftarray = new Vector3[] { new Vector3(113.9f, 51.81f, 139.85f), new Vector3(113.9f, 53.86f, 139.85f), new Vector3(113.9f, 55.21f, 139.85f) };
        downarray = new Vector3[] { new Vector3(100.48f, 58.81f, 139.85f), new Vector3(103f, 58.81f, 139.85f), new Vector3(105f, 58.81f, 139.85f), new Vector3(107f, 58.81f, 139.85f), new Vector3(109f, 58.81f, 139.85f), new Vector3(111f, 58.81f, 139.85f) };
    }

    // Update is called once per frame
    void Update () {
        cooldown2 -= Time.deltaTime;
        if (cooldown2 <= 0)
        {
            if (bc.GetFirePhase() && bc.GetCasting())
            {
                GameObject go;
                if(counter == 4)
                {
                    go = Instantiate(Heart) as GameObject;
                    counter = 0;
                } else
                {
                    go = Instantiate(Fire) as GameObject;
                    counter++;
                }
                go.transform.position = PathChooser(1);
                go.transform.SetParent(transform);
            }
            else if (bc.GetIcePhase() && bc.GetCasting())
            {
                GameObject go;
                if (counter == 4)
                {
                    go = Instantiate(Heart) as GameObject;
                    counter = 0;
                }
                else
                {
                    go = Instantiate(Ice) as GameObject;
                    counter++;
                }
                go.transform.position = PathChooser(2);
                go.transform.SetParent(transform);
            }
            cooldown2 = cooldown;
        }
    }

    private Vector3 PathChooser(int x)
    {
        if (x == 1)
        {
            return leftarray[Random.Range(0, 3)];
        } else if (x == 2)
        {
            return downarray[Random.Range(0, 6)];
        } else
        {
            return Vector3.zero;
        }
    }
}
