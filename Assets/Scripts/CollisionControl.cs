using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionControl : MonoBehaviour
{

    private GameObject platform;
    private Vector3 prevpos;
    public Camera first;
    public Animation anim;
    public Text t1, t2, t3, t4, t5, t6, t7, t8;
    // Use this for initialization
    void Start()
    {
        platform = GameObject.FindGameObjectWithTag("Platform");
    }

    // Update is called once per frame
    void Update()
    {

    }


}