using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaludEnemigo : MonoBehaviour
{
    private int saludMaxima = 300;
    private int health = 180;
    public Slider saludDelEnem;

    private void Update()
    {
        ModificarSalud(0);
        saludDelEnem.value = health;
    }

    public void ModificarSalud(int saludMod) /* se genera una función que tenga un parametro tipo entero, 
        que se utilizara dentro de otra clase para que sirva para acceder al valor privado de la salud*/
    {
        this.health += saludMod;

        /* además se agregan condiciones sobre los valores de la salud */

        if (health <= 0)
        {
            health = 0;

            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }

        if (health > saludMaxima)
        {
            health = saludMaxima;
        }
    }
}
