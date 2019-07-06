using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    float rotationX;
    public int fullHealth = 100;
    public int health = 300;
    public Vector3 posicionJugador;


    void Update()
    {
        rotationX += Input.GetAxis("Mouse X");

        posicionJugador = transform.eulerAngles = new Vector3(0, rotationX, 0);

        AdjustHealth(0);
    }

    
    public void AdjustHealth(int adj)
    {
        health += adj;
        if (health <= 0)
        {
            health = 0;
            if (gameObject != null)
            {
                // haga un empty y llevelo alla;
            }
        }
        if (health > fullHealth)
        {
            health = fullHealth;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponentInParent<IInteract>() != null)
        {
            other.GetComponentInParent<IInteract>().Interact();
        }
    }
}