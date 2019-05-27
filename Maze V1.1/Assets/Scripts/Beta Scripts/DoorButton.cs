using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public GameObject door;

    private bool doorIsActive = true;

    void OpenOrClose()
    {
        doorIsActive = !doorIsActive;
        
        if (doorIsActive)
        {
            door.SetActive(true);
        }
        else
        {
            door.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        OpenOrClose();
    }


}
