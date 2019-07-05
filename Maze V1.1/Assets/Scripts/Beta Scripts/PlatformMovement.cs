using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public Transform[] positionsToGO;
    public bool imDownHere = true;
    public Transform currentToGo;
    public float speed;

    private void Start()
    {
        currentToGo = positionsToGO[0];
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.name == "Jugador1" )
        {
            Switch();
        }
    }
    private void OnCollisionExit(Collision other)
    {
        if (other.transform.name == "Jugador1")
        {
            Switch();
        }

    }

    private void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position,currentToGo.position,speed * Time.deltaTime);

 
    }

    void Switch()
    {

        imDownHere = !imDownHere;

        if (imDownHere)
        {
            currentToGo = positionsToGO[0];
        }
        else
        {
            currentToGo = positionsToGO[1];
        }
    }
}
