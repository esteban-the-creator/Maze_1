using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPCamera : MonoBehaviour
{

    public GameObject elJugador;
    Vector3 intialDistanceToPlyrOffset;
    public float rotateSpeed = 5;

    void Start()

    {
        intialDistanceToPlyrOffset = elJugador.transform.position - transform.position;
    }

    void LateUpdate()
    {
        //Vector3 posicionConstante = elJugador.transform.position + intialDistanceToPlyrOffset;
        //transform.position = posicionConstante;


        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        elJugador.transform.Rotate(0, horizontal, 0);

        float mantenerAnguloConsAlJugador = elJugador.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, mantenerAnguloConsAlJugador, 0);
        transform.position = elJugador.transform.position - (rotation * intialDistanceToPlyrOffset);

        transform.LookAt(elJugador.transform);
    }
}
