using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDamageControl : MonoBehaviour
{
    //General Stats
    public int maxHealth = 5;
    public int currentHealth;

    //Invinsibility timer
    public float timeInvincible = 1.0f;
    bool isInvincible;
    float invincibleTimer;

    //Animator Component
    public Animator animator;

    //Health Return
    public int health { get { return currentHealth; }}

    //knockback
    public Rigidbody2D rb2d;
    public float strength = 16, delay = 0.15f;
    public UnityEvent OnBegin, OnDone,OnDead;

    public bool dead = false;
    public GameObject deathMenuUI;

    public GameObject bonePrefab;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void FixedUpdate()
    {
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

    public void ChangeHealth(int amount)
    {
        if(currentHealth<=0)
            return;
        if (amount < 0)
        {
            GetComponent<FlashControl>().Flash();
            //animator.SetTrigger("hit");
            
            if (isInvincible)
                return;
            
            isInvincible = true;
            invincibleTimer = timeInvincible;
            
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        if(currentHealth<=0)
        {
            dead=true;
            Die();
        }

    }

    
    void Die()
    {
        Debug.Log("Player Died");
        //Death animation
        animator.SetTrigger("Dead");
        //Disable enemy
        deathMenuUI.SetActive(true);
        //On dead event

        for(int i=0;i<5;i++)
            Instantiate(bonePrefab, rb2d.position, Quaternion.identity);

        OnDead?.Invoke();
    }
    


    //Knockback,  modified code from: https://www.youtube.com/watch?v=RXhTD8YZnY4
    public void PlayFeedback(GameObject sender)
    {
        if(currentHealth<=0)
            return;
        StopAllCoroutines();
        OnBegin?.Invoke();
        Vector2 direction = (transform.position-sender.transform.position).normalized;
        rb2d.AddForce(direction*strength,ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(delay);
        rb2d.velocity = Vector3.zero;
        if(currentHealth>0)
            OnDone?.Invoke();
    }

}
