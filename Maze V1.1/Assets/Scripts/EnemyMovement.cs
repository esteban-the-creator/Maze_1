using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform enemyTransform;
    public List<Transform> waitPointTransforms;
    [SerializeField]
    private int actualWaitpoint = 0;
    private float movementSpeed = 5f;

    void Awake()
    {
        enemyTransform = transform;
    }

    public void Move()
    {
        Vector3 actualWaitPointDisplacement = waitPointTransforms[actualWaitpoint].position - enemyTransform.position;
        float distanceToWaitPoint = actualWaitPointDisplacement.magnitude;

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
