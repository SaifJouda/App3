using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{

    public float speed=300;
    
    public string damageTag;

    public int damage=-1;

    Rigidbody2D rigidbody2d;
    
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction)
    {
        rigidbody2d.AddForce(direction * speed);
    }


    
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == damageTag)
        {
            Destroy(gameObject);
            if(other.gameObject.GetComponent<PlayerDamageControl>()!=null)
            {
                other.gameObject.GetComponent<PlayerDamageControl>().ChangeHealth(-1);
                other.gameObject.GetComponent<PlayerDamageControl>().PlayFeedback(gameObject);
            }
            if(other.gameObject.GetComponent<EnemyDamageControl>()!=null)
            {
                other.gameObject.GetComponent<EnemyDamageControl>().ChangeHealth(-1);
                other.gameObject.GetComponent<EnemyDamageControl>().PlayFeedback(gameObject);
            }
        }
    }
    
}
