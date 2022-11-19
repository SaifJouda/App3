using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.GetComponent<PlayerDamageControl>()!=null)
        {
            other.GetComponent<PlayerDamageControl>().ChangeHealth(-1);
            other.GetComponent<PlayerDamageControl>().PlayFeedback(gameObject);
        }
    }
}
