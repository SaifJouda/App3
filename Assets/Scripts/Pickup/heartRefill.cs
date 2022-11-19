using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartRefill : MonoBehaviour
{
    private GameObject player;
    void Start() 
    {
        player=GameObject.Find("Player");    
    }
    void pickUp()
    {
        Destroy(gameObject);

    }
}
