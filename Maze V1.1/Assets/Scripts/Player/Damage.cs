using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    private float fuerza = 200;
    public AudioClip shooting;
    public int cantDamage = 10;
    private RaycastHit objetoImpactado;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Disparar();
        }
    }

    public void Disparar()

    {
        AudioSource.PlayClipAtPoint(shooting, Camera.main.transform.position);

        Ray disparo = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(disparo.origin, disparo.direction * 100, Color.red, 1);


        if (Physics.Raycast(disparo, out objetoImpactado)) // si dentro de la clase physics el rayo impacta un objeto ejecutar:
        {

            if (objetoImpactado.transform.tag == "Enemy" && objetoImpactado.rigidbody != null) // si el tag del objeto impactado es "Enemy" y su  rigidbody es distinto a null (osea, sí lo tiene) ejecutar esto:
            {
                objetoImpactado.rigidbody.AddForceAtPosition(disparo.direction * fuerza, objetoImpactado.point); // se le añade fuerza al bojeto impactado para moverlo 

                objetoImpactado.transform.GetComponent<SaludEnemigo>().ModificarSalud(-cantDamage); /* se accede al script de salud del objeto que impactó y se modifica la salud 
                del enemigo pasando como parametro el valor del daño que se espera que se haga por cada disparo */
            }
        }
    }
}

