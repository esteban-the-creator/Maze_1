using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(requiredComponent: typeof(EnemyBehaviour))]

public class EnemyPatrollingA : MonoBehaviour
{
    private Transform enemyTransform;
    public List<Transform> waitPointTransforms;
    [SerializeField]
    private int actualWaitpoint = 0;
    private float movementSpeed = 5f;
    EnemyBehaviour detectar;

    void Awake()
    {
        enemyTransform = transform;
        detectar = gameObject.GetComponent<EnemyBehaviour>();//le añade al gamecomponent detectar al objeto al que se le asigne este script de patrullaje
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        Vector3 actualWaitPointDisplacement = waitPointTransforms[actualWaitpoint].position - enemyTransform.position; // waitPointTransforms[actualWaitpoint].position significa: listadetransform[en la pos actual].position (se accede al transform.position del empty actual)
        float distanceToWaitPoint = actualWaitPointDisplacement.magnitude;

        Debug.Log ("el valor de la detección es : " + detectar.getDeteccion());

        if (detectar.getDeteccion() == false)
        {
            if (distanceToWaitPoint > 1)
            {
                Vector3 directionVector = actualWaitPointDisplacement.normalized;
                enemyTransform.position += directionVector * movementSpeed * Time.deltaTime;
            }

            else
            {
                actualWaitpoint++;
                if (actualWaitpoint >= waitPointTransforms.Count)
                    actualWaitpoint = 0;
            }
        }
    }
}
