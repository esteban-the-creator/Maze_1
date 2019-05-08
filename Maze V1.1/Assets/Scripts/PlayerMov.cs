using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public GameObject mahHero;
    public float heroSpeed = 10f;
    float rotationX;
    float rotationY;
    Rigidbody herorigidbody;


    void Start()

    {
        herorigidbody = mahHero.AddComponent<Rigidbody>();

        herorigidbody.constraints = RigidbodyConstraints.FreezeRotation ; /* se congela la rotación del personaje para evitar que obtenga algun angulo que haga que esté 
        en caida libre constante y evitar un desplazamiento no deseado */
        herorigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        herorigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;/* Una solución efectiva para la colisiones que haga el jugador es hacer que la
        detección de colisiones del rigidbody sea continua dinámica*/

        mahHero.AddComponent<Camera>();
    }


    void Update() // frame a frame se verifica la pulsación de las las letras "w,a,s,d" para poder realizar el movimiento del heroe

       
    {


        if (Input.GetKey(KeyCode.W))
        {
            RaycastHit detectWall;

            if (Physics.Raycast(transform.position, transform.forward, out detectWall, Mathf.Infinity, 8))
            {
                Vector3 MovW = new Vector3(mahHero.transform.forward.x * 0.4F, 0, mahHero.transform.forward.z * 0.4F);
                herorigidbody.position += MovW * 2 * Time.deltaTime;
            }

            else
            {
                Vector3 MovW = new Vector3(mahHero.transform.forward.x , 0, mahHero.transform.forward.z );
                herorigidbody.position += MovW * heroSpeed * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.S))

        {
            herorigidbody.position -= new Vector3(mahHero.transform.forward.x, 0, mahHero.transform.forward.z) * heroSpeed * Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.D))

        {
            herorigidbody.position += mahHero.transform.right * heroSpeed * Time.deltaTime;
        }


        if (Input.GetKey(KeyCode.A))

        {
            herorigidbody.position -= mahHero.transform.right * heroSpeed * Time.deltaTime; /* Ya que estamos modificando al posición del hero con físicas 
            a través  del rigidbody, lo más correcto es que el desplazamiento se haga accediendo al position del rigidbody en vez del transform.position. En la igualdad
           se hace una excepción cuando usamos transform.right ya que esta frase nos entrega un vector normalizado y no directamente usamos el transform*/
        }

        /* 
         Se asginan a los atributos de clase"rotation" los valores de los ejes Y y X obtenidos con el mouse 
         luego se llama al atributo eulerAngles de la clase transform del objeto mahHero y con un new 
         vector 3 se le asignan los valores obtenidos a través del mouse; esto con el fin de poder rotar la camara 
         a través del escenario
        */

        //if (Input.GetAxis("Mouse X") < 45 || Input.GetAxis("Mouse X") > -45)
        
        rotationX += Input.GetAxis("Mouse X");
        
        rotationY += Input.GetAxis("Mouse Y");

        //mahHero.transform.rotation =  (rotationX, rotationY * -1, 0f);
        mahHero.transform.eulerAngles = new Vector3(rotationY * -1, rotationX , 0);

        // Vector3 newrotation = mahHero.transform.eulerAngles;
        // newrotation.x = 0;
        //newrotation.z = 0;

        //mahHero.transform.eulerAngles = newrotation;


        herorigidbody.velocity = Vector3.zero; /* se iguala el vector de velocidad del rigidbody del heroe para evitar 
        que la acelareación que obtenga al colisionar con otros objetos fisicos que también tengan rigidbody, lo haga 
        trasladar infinitamente gracias a la aceleración constante que obteien con el choque.
        
        Esto sucede gracias a las física que está usando el juego y con las que estamos haciendo mover al jugador */

        herorigidbody.angularVelocity = Vector3.zero; /* A parte de la velocidad normal, también está la velocidad 
        angular, lo cual también puede afectar el correcto desplazamiento del heroe, por lo cual también es importante 
        mantenerla igualada a 0*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<IInteract>() != null )
        {
            other.GetComponentInParent<IInteract>().Interact(); 
        }
    }
}



