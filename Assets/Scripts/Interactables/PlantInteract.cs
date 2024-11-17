using UnityEngine;
using System.Collections;

public class PlantInteract : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject objectToAppear;
    public float displayTime = 3f;
    public float cooldownTime = 1f;

    private bool isCooldown = false;

    private void OnMouseDown()
    {
        if (isCooldown)
            return;

        isCooldown = true;

        if (audioSource != null)
        {
            audioSource.Play();
        }

        if (objectToAppear != null)
        {
            objectToAppear.SetActive(true);
            StartCoroutine(DeactivateObjectAfterTime());
        }

        StartCoroutine(Cooldown());
    }

    private IEnumerator DeactivateObjectAfterTime()
    {
        yield return new WaitForSeconds(displayTime);
        if (objectToAppear != null)
        {
            objectToAppear.SetActive(false);
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
    }
}
