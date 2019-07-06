using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public GameObject target;
    public float power = 200;
    public AudioClip shooting;

    private void Awake()
    {
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AudioSource.PlayClipAtPoint(shooting,Camera.main.transform.position);

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


