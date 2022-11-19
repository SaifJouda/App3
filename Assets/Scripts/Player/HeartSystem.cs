using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystem : MonoBehaviour
{
    [HideInInspector]
    public int health;
    [HideInInspector]
    public int maxHealth;

    public Image[] hearts;
    public Sprite heartFull;
    public Sprite heartEmpty;

    void Update()
    {
        health=GetComponent<PlayerDamageControl>().currentHealth;
        maxHealth=GetComponent<PlayerDamageControl>().maxHealth;
        if(health>maxHealth)
            health=maxHealth;
        if(health<0)
            health = 0;
        for (int i=0;i<hearts.Length;i++)
        {
            if(i<health)
                hearts[i].sprite=heartFull;
            else
                hearts[i].sprite=heartEmpty;
            if(i<maxHealth)
                hearts[i].enabled=true;
            else
                hearts[i].enabled=false;
        }
    }
}
