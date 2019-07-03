using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPCamera : MonoBehaviour
{
    public GameObject target;
    private Camera cam;
    private Transform camTransform;
    public float rotateSpeed = 5;
    Vector3 offset;

    void Start()
    {
       
        cam = Camera.main;
        camTransform = cam.transform;
        offset = camTransform.position - target.transform.position;

    }

    void LateUpdate()
    {
        
        Debug.Log("offset de la camara" + offset);
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotationX = Quaternion.Euler(45, desiredAngle, 0);
        camTransform.rotation = rotationX;
        camTransform.position = target.transform.position + offset;

       if (Input.GetButton("Fire1"))
        {
            float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
            camTransform.rotation = Quaternion.Euler(vertical, desiredAngle, 0f);
        }
        //camTransform.LookAt(target.transform);
    }
}

