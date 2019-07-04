﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPCamera : MonoBehaviour
{
    public GameObject target;
    private Camera cam;
    private Transform camTransform;
    public float rotateSpeed = 5;
    float angleY;
    Vector3 offset;

    void Start()
    {
       
        cam = Camera.main;
        camTransform = cam.transform;
        offset = camTransform.position - target.transform.position;

    }

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            angleY = Input.GetAxis("Mouse Y") * rotateSpeed;
            //camTransform.rotation = Quaternion.Euler(angleY, desiredAngle, 0);
            camTransform.Rotate(angleY, 0, 0);
        }
        //camTransform.LookAt(target.transform);
        print("angleY" + angleY);

    }

    void LateUpdate()
    {
        
        Debug.Log("offset de la camara" + offset);
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        //float desiredAngle = target.transform.eulerAngles.y;
        //Quaternion rotationX = Quaternion.Euler(45, desiredAngle, 0);
        camTransform.Rotate (0,horizontal,0);

        camTransform.position = target.transform.position + offset;

      
    }
}
