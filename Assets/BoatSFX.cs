using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSFX : MonoBehaviour
{
    public AudioClip[] scuttle;
    public AudioClip harpoonShoot;
    public AudioSource source;
    
    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
