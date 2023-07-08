using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    private float timer;
    public TextMeshProUGUI finalTime;
    private Animator transcendAnimator;
    private bool transcended = false;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        transcendAnimator = GameObject.Find("CameraFadeAlpha").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    public void Transcend() {
        if (!transcended) {
            finalTime.text = "You transcended in only\n" + timer + " fish seconds";
            transcendAnimator.SetTrigger("Transcend");
            transcended = true;
        }
        
    }
}
