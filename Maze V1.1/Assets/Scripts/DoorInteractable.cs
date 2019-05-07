using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractable : MonoBehaviour, IInteract
{
    public void Interact()
    {
        gameObject.SetActive(false);
    }
}