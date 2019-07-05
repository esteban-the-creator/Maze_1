using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(requiredComponent: typeof(Animator))]

public class LargeDoorAnim : MonoBehaviour, IInteract
{
    public Animator animController;

    public void Start()
    {
        animController = GetComponent<Animator>();
    }

    public void Abrir()
    {
        animController.SetBool("OpenOrClose", true);

    }

    public void Interact()
    {
        Abrir();
    }
}