using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class Damage : MonoBehaviour
{
    float salud = 1000;
    Detectar detectar;

    void Awake()
    {
        
        //detectar = gameObject.GetComponent<Detectar>();//le añade al gamecomponent detectar al objeto al que se le asigne este script de patrullaje
    }

    private void Update()
    {
        DañoRecibido();
    }

    void DañoRecibido()
    {
        Debug.Log("la salud es" + salud);

        if (detectar.getDeteccion() == true)
        {
            salud -= 5;
        }
    }
}*/


public class Damage : MonoBehaviour
{

    public GameObject target;
    public float power = 200;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Attack();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(transform.position, Vector3.forward * 100, Color.red);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 25.0f))
            {
                hitInfo.rigidbody.AddForceAtPosition(ray.direction * power, hitInfo.point);

                if (hitInfo.rigidbody.tag == "Enemy" && hitInfo.rigidbody != null) 
                {
                    SaludEnemigo saluEnem = hitInfo.collider.GetComponent<SaludEnemigo>();
                    //(SaludEnemigo)target.GetComponent("SaludEnemigo");


                    saluEnem.AdjustHealth(-10);
                }
            }
        }
    }
}


