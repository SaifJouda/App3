using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OpenDoor : MonoBehaviour
{
    public Transform openPoint;
    public float openRange = 1.0f;
    public LayerMask doorLayer;
    private bool keyAquired=false;
    public UnityEvent doorOpen;

    public Image keyIcon;
    public Sprite falseKey;
    public Sprite trueKey;

    void Start() {
        keyIcon.sprite=falseKey;
    }

   void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            openDoor();
        }
    }

    public void pickUpKey()
    {
        keyAquired=true;
        keyIcon.sprite=trueKey;
    }

    void openDoor()
    {
        //Detection
        Collider2D[] doorInRange = Physics2D.OverlapCircleAll(openPoint.position, openRange, doorLayer);

        //Pick
        if(doorInRange.Length>0 && keyAquired==true )
        {
            doorOpen?.Invoke();
        }

    }


}
