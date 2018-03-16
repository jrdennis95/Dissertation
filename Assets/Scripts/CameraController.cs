using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform tar;
    public Vector3 startingPosition;

    // Use this for initialization
    void Start()
    {
        startingPosition = tar.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = tar.position - startingPosition;
    }
}
