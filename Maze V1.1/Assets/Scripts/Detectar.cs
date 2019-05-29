using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[RequireComponent( requiredComponent: typeof(EnemyMovement))]

public class Detectar : MonoBehaviour
{

    public Transform playerTransform;
    Transform enemyTransform;
    public GameObject warning;
    public GameObject alert;
    [SerializeField]
    float rangoDeVision = 10f;
    float precaucion;
    EnemyMovement enemyMovement;

    void Awake()
    {
        enemyTransform = transform;
        enemyMovement = gameObject.GetComponent<EnemyMovement>();
    }



    void Update()
    {
        bool playerAlaVista = JugadorVisible();


        if (playerAlaVista == true)
        {
            precaucion += Time.deltaTime;

            if (precaucion > 1f)
            {
                warning.SetActive(true);

                if (precaucion > 3f)
                {
                    warning.SetActive(false);
                    alert.SetActive(true);
                }

            }
        }
        else
        {
            alert.SetActive(false);
            precaucion = 0;
            enemyMovement.Move();
        }


    }


    bool JugadorVisible()
    {
        Vector3 spaceBtwnCharacters = playerTransform.position - enemyTransform.position; // se cea una variable Vector3, que guarda el valor de la distancia entre el espacio de la posición del jugador y enemigo
        float distanceToPlayer = spaceBtwnCharacters.magnitude; // se le asgina el valor del espacio, que fue guardado en la "magnitud" de la variable spaceBtwnCharacters a una variable floatante, para trabajar más facilmente con ésta.

        if (rangoDeVision > distanceToPlayer) // si el rangoDeVision es mayor a la distanceToPlayer, es porque el jugador esá dentro del parametro de visión.
        {
            float productoPunto = Vector3.Dot(enemyTransform.forward, spaceBtwnCharacters.normalized);

            if (productoPunto >= 0.5f) // si el productoPunto es mayor que 0.5 unidades se activa el Raycast. Se hace que sea mayor a un numero pequeño para evitar que el rayo choque con el objeto de origen.
            {
                RaycastHit impactado;

                Debug.DrawRay(enemyTransform.position + spaceBtwnCharacters.normalized * 1.01f, spaceBtwnCharacters.normalized * 100, Color.blue);


                if (Physics.Raycast(enemyTransform.position + spaceBtwnCharacters.normalized * 1f, spaceBtwnCharacters.normalized, out impactado, Mathf.Infinity))
                {
                    Debug.DrawRay(enemyTransform.position + spaceBtwnCharacters.normalized * 1f, spaceBtwnCharacters.normalized * impactado.distance, Color.yellow);

                    if (impactado.collider.gameObject.name == "Jugador1")
                    {
                        return true;
                    }
                }
            }

        }

        return false;
    }

}

/* 
 [SerializeField] : Esta palabra reservada entre corchetes hace que se vea en el inspector de Unity los datos privados;
 [HideInInspector]: Mientras que esta linea hace que un elemento público no se vea en el inspector de Unity;
*/
