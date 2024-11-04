using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{

    public static Audio instance;
    [Header("Audio")]
    [SerializeField] AudioSource music;

    public AudioClip musicClip;
    private void Awake()
    { 
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        music.clip = musicClip;
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
