using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSFX : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] scuttles;
    public AudioClip harpoon;
    public float scuttleVolume = 0.1f;
    public float harpoonVolume = 0.05f;
    
    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    public void PlayScuttleSound() {
        source.volume = scuttleVolume;
        source.clip = scuttles[Random.Range(0, scuttles.Length)];
        source.Play();
    }

    public void PlayHarpoonSound() {
        source.volume = harpoonVolume;
        source.clip = harpoon;
        source.Play();
    }
}
