using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public float speedH;
    public float speedV;
    public GameObject robot;
    float yaw;
    float pitch;

    // Update is called once per frame
    void Update()
    {
        transform.position = robot.transform.position;
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
    }
}
