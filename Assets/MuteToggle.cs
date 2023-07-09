using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MuteToggle : MonoBehaviour
{
    
    public GameObject soundOn;
    public GameObject soundOff;
    
    public void ToggleSound() {
        //AudioListener AudioListener = GameObject.Find("Main Camera").GetComponent<AudioListener>();
        if (AudioListener.volume == 0) {
            AudioListener.volume = 1;
            soundOn.SetActive(true);
            soundOff.SetActive(false);
        }
        else {
            AudioListener.volume = 0;
            soundOn.SetActive(false);
            soundOff.SetActive(true);
        }
    }
}
