using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponSelector : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite spear;
    public Sprite knife;
    public Sprite axe;
    public Sprite woodMace;
    public Sprite spikeyKnife;
    public Sprite metalMace;

    private GameObject spearGO, knifeGO, axeGO, woodMaceGO, spikeyKnifeGO, metalMaceGO; 

    public int currentWpn=0;

    void Start() {
        spearGO = (GameObject)Resources.Load("spearPickUp", typeof(GameObject));
        knifeGO = (GameObject)Resources.Load("knifePickUp", typeof(GameObject));
        axeGO = (GameObject)Resources.Load("axePickUp", typeof(GameObject));
        woodMaceGO = (GameObject)Resources.Load("woodMacePickUp", typeof(GameObject));
        spikeyKnifeGO = (GameObject)Resources.Load("spikeyKnifePickUp", typeof(GameObject));
        metalMaceGO = (GameObject)Resources.Load("metalMacePickUp", typeof(GameObject));
    }

    public void swap(int i)
    {
        if(currentWpn==0) Instantiate(spearGO, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        if(currentWpn==1) Instantiate(knifeGO, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        if(currentWpn==2) Instantiate(axeGO, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        if(currentWpn==3) Instantiate(woodMaceGO, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        if(currentWpn==4) Instantiate(spikeyKnifeGO, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        if(currentWpn==5) Instantiate(metalMaceGO, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);

        if(i==0) spriteRenderer.sprite=spear;
        if(i==1) spriteRenderer.sprite=knife;
        if(i==2) spriteRenderer.sprite=axe;
        if(i==3) spriteRenderer.sprite=woodMace;
        if(i==4) spriteRenderer.sprite=spikeyKnife;
        if(i==5) spriteRenderer.sprite=metalMace;
        currentWpn=i;
    }
}
