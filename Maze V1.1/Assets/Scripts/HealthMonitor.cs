using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMonitor : MonoBehaviour
{
    //https://www.youtube.com/watch?v=_2A3wfgEbas&list=PLZ1b66Z1KFKhYiO4XcGuCksRugDvj-H6i Mini Unity Tutorial - How To Make A HEALTH BAR LIKE FALLOUT 4
    public float healthLength = 188;
    public float healthPos = 63.8f;
    public GameObject healthBar;
    public float damageReceived;
    public bool decreasingHealth = false;
    public bool increasingHealth = false;
    PlayerBehaviour datosDelPlayer;


    void Start ()
    {
        
       
        datosDelPlayer = gameObject.GetComponent<PlayerBehaviour>();  
    }

   
    void Update()
    {
        damageReceived = datosDelPlayer.health;

        healthBar.transform.position = new Vector2(healthPos, -30.96f);
        healthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(healthLength, 24);
    }
}
