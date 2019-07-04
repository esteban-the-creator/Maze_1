using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
  { 
    private Transform platformTransform;
    public Transform[] waitPointTransforms = new Transform[2];
    [SerializeField]
    //private int actualWaitpoint = 0;
    private float movementSpeed = 5f;
    private float waiting;
    private bool switche;
    
    void Awake()
    {
        platformTransform = transform;
    }

    void OnMouseDown()
    {
        switche = !switche;
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
       /* Vector3 actualWaitPointDisplacement = waitPointTransforms[actualWaitpoint].position - platformTransform.position; // waitPointTransforms[actualWaitpoint].position significa: listadetransform[en la pos actual].position (se accede al transform.position del empty actual)
        float distanceToWaitPoint = actualWaitPointDisplacement.magnitude;
        */
        if (switche == true) {

        Vector3 actualWaitPointDisplacement = waitPointTransforms[1].position;

        Vector3 directionVector = actualWaitPointDisplacement.normalized;
                platformTransform.position += directionVector * movementSpeed * Time.deltaTime;

                for (waiting = 0; waiting < 5; waiting++)
                { waiting *= Time.deltaTime; };
        }

        else {
            Vector3 actualWaitPointDisplacement = waitPointTransforms[0].position;

            Vector3 directionVector = actualWaitPointDisplacement.normalized;
            platformTransform.position += directionVector * movementSpeed * Time.deltaTime;

            for (waiting = 0; waiting < 5; waiting++)
            { waiting *= Time.deltaTime; };
        }
    }    
}
