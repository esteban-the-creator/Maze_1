using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaludEnemigo : MonoBehaviour
{

    public int fullHealth = 100;
    public int health = 100;
    //public float healthBar;


    //void Start()
    //{
    //    healthBar = Screen.width / 2;
    //}


    void Update()
    {
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
                Destroy(gameObject);
            }
        }
        if (health > fullHealth)
        {
            health = fullHealth;
        }

    }
}
