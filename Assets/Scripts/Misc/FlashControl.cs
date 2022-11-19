using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashControl : MonoBehaviour
{

    public Material flashMaterial;
    public float duration=0.5f;
    public SpriteRenderer[] spriteRenderer;
    public Material[] originalMaterial;
    private Coroutine flashRoutine;


    // Start is called before the first frame update
    void Start()
    {
        int i=0;
        foreach(SpriteRenderer sr in spriteRenderer)
        {
            originalMaterial[i]=spriteRenderer[i].material;
            i++;
        }
    }

    public void Flash()
    {
        // If the flashRoutine is not null, then it is currently running.
        if (flashRoutine != null)
        {
            // In this case, we should stop it first.
            // Multiple FlashRoutines the same time would cause bugs.
            StopCoroutine(flashRoutine);
        }

        // Start the Coroutine, and store the reference for it.
        flashRoutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        // Swap to the flashMaterial.
        //spriteRenderer.material = flashMaterial;
        int i=0,j=0;
        foreach(SpriteRenderer sr in spriteRenderer)
        {
           spriteRenderer[i].material = flashMaterial;
            i++;
        }

        // Pause the execution of this function for "duration" seconds.
        yield return new WaitForSeconds(duration);

        // After the pause, swap back to the original material.
        //spriteRenderer.material = originalMaterial;
        foreach(SpriteRenderer sr in spriteRenderer)
        {
           spriteRenderer[j].material = originalMaterial[j];
            j++;
        }

        // Set the routine to null, signaling that it's finished.
        flashRoutine = null;
    }
}
