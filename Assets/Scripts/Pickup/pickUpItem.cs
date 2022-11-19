using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpItem : MonoBehaviour
{
    public enum itemType {heartPickUp,monsterHeart, spear,knife, axe, woodMace, spikeyKnife, metalMace, key, damageBuff};   
    private GameObject player;
    public itemType typeOfItem;

    void Start() 
    {
        player=GameObject.Find("Player");    
    }

    public void pickUp()
    {
        Destroy(gameObject);
        handlePickUp();
    }

    private void handlePickUp()
    {
        if(typeOfItem==itemType.heartPickUp)
        {
            player.GetComponent<PlayerDamageControl>().currentHealth = player.GetComponent<PlayerDamageControl>().maxHealth;
        }

        if(typeOfItem==itemType.monsterHeart)
        {
            player.GetComponent<PlayerDamageControl>().maxHealth++;
            player.GetComponent<PlayerDamageControl>().currentHealth++;
        }

        if(typeOfItem==itemType.spear)
        {
            player.GetComponent<weaponSelector>().swap(0);
            //damage, range, cool
            player.GetComponent<PlayerMelee>().changeWpnStats(-1,1.25f,1.0f);
        }

        if(typeOfItem==itemType.knife)
        {
            player.GetComponent<weaponSelector>().swap(1);
            player.GetComponent<PlayerMelee>().changeWpnStats(-1,0.75f,0.55f);
        }

        if(typeOfItem==itemType.axe)
        {
            player.GetComponent<weaponSelector>().swap(2);
            player.GetComponent<PlayerMelee>().changeWpnStats(-2,1.0f,1.25f);
        }

        if(typeOfItem==itemType.woodMace)
        {
            player.GetComponent<weaponSelector>().swap(3);
            player.GetComponent<PlayerMelee>().changeWpnStats(-2,1.25f,1.5f);
        }

        if(typeOfItem==itemType.spikeyKnife)
        {
            player.GetComponent<weaponSelector>().swap(4);
            player.GetComponent<PlayerMelee>().changeWpnStats(-2,0.75f,0.65f);
        }

        if(typeOfItem==itemType.metalMace)
        {
            player.GetComponent<weaponSelector>().swap(5);
            player.GetComponent<PlayerMelee>().changeWpnStats(-3,1.5f,1.5f);
        }
        if(typeOfItem==itemType.key)
        {
            player.GetComponent<OpenDoor>().pickUpKey();
        }
        if(typeOfItem==itemType.damageBuff)
        {
            player.GetComponent<PlayerMelee>().weaponBuffDamage();
        }

    }
}
