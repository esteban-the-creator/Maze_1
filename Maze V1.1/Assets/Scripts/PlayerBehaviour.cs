using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<IInteract>() != null)
        {
            other.GetComponentInParent<IInteract>().Interact();
        }
    }
}

public void Moverse
{

}