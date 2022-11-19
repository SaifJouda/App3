using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemDrop : MonoBehaviour
{
    private GameObject heartPickup;
    private GameObject monsterHeart;
    private GameObject key;
    private GameObject damageBuff;
    private GameObject spearGO, knifeGO, axeGO, woodMaceGO, spikeyKnifeGO, metalMaceGO; 

    void Start() {
        heartPickup = (GameObject)Resources.Load("heartPickup", typeof(GameObject));
        monsterHeart = (GameObject)Resources.Load("MonsterHeart", typeof(GameObject));
        key = (GameObject)Resources.Load("BoneKey", typeof(GameObject));
        damageBuff = (GameObject)Resources.Load("damageBuff", typeof(GameObject));

        spearGO = (GameObject)Resources.Load("spearPickUp", typeof(GameObject));
        knifeGO = (GameObject)Resources.Load("knifePickUp", typeof(GameObject));
        axeGO = (GameObject)Resources.Load("axePickUp", typeof(GameObject));
        woodMaceGO = (GameObject)Resources.Load("woodMacePickUp", typeof(GameObject));
        spikeyKnifeGO = (GameObject)Resources.Load("spikeyKnifePickUp", typeof(GameObject));
        metalMaceGO = (GameObject)Resources.Load("metalMacePickUp", typeof(GameObject));
    }
    public void drop()
    {
        if(Random.value > 0.5) //50% chance to drop an item
        {
            //choose what item to drop
            if(Random.value > 0.7) //30% drop heart
                Instantiate(heartPickup, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            if(Random.value > 0.8) //20% drop heart
                Instantiate(monsterHeart, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            if(Random.value > 0.9) //10% drop heart
                Instantiate(damageBuff, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            if(Random.value > 0.8) //20% chance
            {
                if(Random.value>0.9) Instantiate(metalMaceGO, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                else if(Random.value>0.75) Instantiate(spikeyKnifeGO, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                else if(Random.value>0.50) Instantiate(knifeGO, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                else if(Random.value>0.25) Instantiate(woodMaceGO, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
                else if(Random.value>0.0) Instantiate(axeGO, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            }
            
        }
    }

    public void dropKey()
    {
        Debug.Log("Key dropped");
        Instantiate(key, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
    }
}
