using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform tar;
    public Vector3 startingPosition;
    public Camera cam2, cam3, cam4;

    // Use this for initialization
    void Start()
    {
        startingPosition = tar.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = tar.position - startingPosition;

        if (Input.GetKey(KeyCode.O) && Camera.main.orthographic == false)
        {
            Camera.main.orthographicSize = 3.3f;
            cam2.orthographicSize = 3.3f;
            cam3.orthographicSize = 3.3f;
			cam4.orthographicSize = 3.3f;
            Camera.main.orthographic = true;
            cam2.orthographic = true;
            cam3.orthographic = true;
			cam4.orthographic = true;
        } else if (Input.GetKey(KeyCode.P) && Camera.main.orthographic == true)
        {
            Camera.main.orthographic = false;
            cam2.orthographic = false;
            cam3.orthographic = false;
			cam4.orthographic = false;
        }
    }
}
