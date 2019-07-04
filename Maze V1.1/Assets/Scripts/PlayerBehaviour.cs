using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    float rotationX;

    public Vector3 posicionJugador;


    void Update()
    {
        rotationX += Input.GetAxis("Mouse X");

        posicionJugador = transform.eulerAngles = new Vector3(0, rotationX, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponentInParent<IInteract>() != null)
        {
            other.GetComponentInParent<IInteract>().Interact();
        }
    }
}