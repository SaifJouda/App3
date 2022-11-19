using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpMechanic : MonoBehaviour
{
    public Transform pickUpPoint;
    public float pickRange = 1.0f;
    public LayerMask pickLayer;
    public LayerMask wpnLayer;
    



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            PickUp();
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            SwapWpn();
        }
    }

    void PickUp()
    {
        //Detection
        Collider2D[] itemsInRange = Physics2D.OverlapCircleAll(pickUpPoint.position, pickRange, pickLayer);

        //Pick
        foreach(Collider2D item in itemsInRange)
        {
            item.GetComponent<pickUpItem>().pickUp();
        }
    }

    void SwapWpn()
    {
        //Detection
        Collider2D[] wpnInRange = Physics2D.OverlapCircleAll(pickUpPoint.position, pickRange, wpnLayer);

        //Pick
        if(wpnInRange.Length>0)
        {
            wpnInRange[0].GetComponent<pickUpItem>().pickUp();
          
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(pickUpPoint.position,pickRange);
    }
}
