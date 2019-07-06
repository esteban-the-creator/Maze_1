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
            Debug.DrawRay(ray.origin,  ray.direction * 100, Color.red,1);

            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
              
                if (hitInfo.transform.tag == "Enemy" && hitInfo.rigidbody != null) 
                {
                    hitInfo.rigidbody.AddForceAtPosition(ray.direction * power, hitInfo.point);

                    hitInfo.transform.GetComponent<SaludEnemigo>().AdjustHealth(-10);
                }
            }
        }
    }
}


