using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject lightOn;

    private bool isActive = false;

    private void OnMouseDown()
    {
        isActive = !isActive;

        if (lightOn != null)
        {
            lightOn.SetActive(isActive);
        }

        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
