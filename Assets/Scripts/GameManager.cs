using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool gameIsOver;
    private float timer;
    public TextMeshProUGUI finalTime;
    private Animator transcendAnimator;
    private bool transcended = false;
    private Fish m_fish;
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

    public void Transcend() 
    {
        if (!transcended) {
            finalTime.text = "You transcended in only\n" + timer + " fish seconds";
            transcendAnimator.SetTrigger("Transcend");
            transcended = true;
            GameOver("Transcended");
        }
        
    }

    public void GameOver(string GameOverReason)
    {

        gameIsOver = true;
        m_fish.moveSpeed = 0;

    }
}
