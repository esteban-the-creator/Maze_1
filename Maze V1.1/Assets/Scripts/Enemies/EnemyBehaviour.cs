using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehaviour : MonoBehaviour
{

    public Transform playerTransform;
    private Transform enemyTransform;
    public GameObject warning;
    public GameObject alert;
    public RaycastHit impactado;
    public AudioClip enemGunSound;
    public float rangoDeVision = 15f;
    private float precaucion;
    [SerializeField] //Indice1(ver final del cod)

    private void Awake() // se asignan los objetos de unity a las variables; 
    {
        enemyTransform = transform; //la var enemyTransform se iguala al transform del objeto al que le sea asignado este script;
        warning = this.transform.Find("Warning").gameObject;
        alert = this.transform.Find("Alert").gameObject;

        /* se indica que busque el gameobject empty "PlayerCenter" en toda la jerarquia para que se lo agrege a la variable,
           en caso de no encontrarlo avise con un warning;*/
        try
        {
            playerTransform = GameObject.Find("PlayerCenter").transform;
        }
        catch
        {
            Debug.LogWarning("No encontré un objeto con el nombre de PlayerCenter");
        }
    }

    private void Update()
    {
        DetectarAlPlayer();
        Atacar();
    }

     private bool JugadorVisible()
    {
        Vector3 spaceBtwnCharacters = playerTransform.position - enemyTransform.position; // se cea una variable Vector3, que guarda el valor de la distancia entre el espacio de la posición del jugador y enemigo
        float distanceToPlayer = spaceBtwnCharacters.magnitude; // se le asgina el valor del espacio, que fue guardado en la "magnitud" de la variable spaceBtwnCharacters (que es un vector, por ende tiene magnitud) y lo pasa a una variable floatante, para trabajar más facilmente con ésta.

        if (rangoDeVision > distanceToPlayer) // si el rangoDeVision es mayor a la distanceToPlayer, es porque el jugador esá dentro del parametro de visión.
        {
            float productoPunto = Vector3.Dot(enemyTransform.forward, spaceBtwnCharacters.normalized);

            if (productoPunto >= 0.5f) // si el productoPunto es mayor que 0.5 unidades se activa el Raycast. Se hace que sea mayor a un numero pequeño para evitar que el rayo choque con el objeto de origen.
            {
                Debug.DrawRay(enemyTransform.position, spaceBtwnCharacters.normalized * 100, Color.blue);

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

    private bool  DetectarAlPlayer() // funcion que ejecuta la detección del Jugador1 y activa los simbolos de precaución y alerta  
    {
        bool playerAlaVista = JugadorVisible();

        if (playerAlaVista == true)
        {
            precaucion += Time.deltaTime;
            enemyTransform.LookAt(playerTransform);

            if (precaucion > 1f)
            {
                warning.SetActive(true);

                if (precaucion > 3f)
                {
                    warning.SetActive(false);
                    alert.SetActive(true);
                    return true;
                }
            }
        }
        else
        {
            alert.SetActive(false);
            precaucion = 0; 
        }

        return false;
    }

    private void Atacar()
    {
        if (DetectarAlPlayer() == true)
        {
            impactado.transform.GetComponent<PlayerBehaviour>().AdjustHealth(-1);
            AudioSource.PlayClipAtPoint(enemGunSound, enemyTransform.position);

        }
        
    }

   

       public bool getDeteccion() // propiedad que retorna el valor booleano de la funcion con retorno "JugadorVisible()" para que sea accesible a otras clases;
    {
       return JugadorVisible();
    }

}



/* 
 Indice1
 [SerializeField] : Esta palabra reservada entre corchetes hace que se vea en el inspector de Unity los datos privados;
 [HideInInspector]: Mientras que esta linea hace que un elemento público no se vea en el inspector de Unity;
*/
