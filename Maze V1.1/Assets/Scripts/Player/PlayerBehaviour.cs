using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{
    private float rotationX;
    public int fullHealth = 200;
    public int health = 188;
    private Vector3 posicionJugador;
    public Slider healthBar;
    public Transform respawnPoint;


    void Update()
    {
        rotationX += Input.GetAxis("Mouse X");

        posicionJugador += transform.eulerAngles = new Vector3(0, rotationX, 0);

        AdjustHealth(0);
        
        //print("la salud del player1 es: " + health);
    }

    
    public void AdjustHealth(int adj)
    {
        health += adj;

        healthBar.value = health;

        if (health <= 0)
        {
            health = 0;
            if (gameObject != null)
            {
                transform.position = respawnPoint.position;
                health = fullHealth;
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