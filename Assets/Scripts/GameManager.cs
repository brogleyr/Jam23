using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject m_playAgain;
    public bool gameIsOver;
    private float timer;
    public TextMeshProUGUI finalTime;
    private Animator transcendAnimator;
    private bool transcended = false;
    private Fish m_fish;
    public TextMeshProUGUI gameOverReasonText;
    public TextMeshProUGUI gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        m_fish = GameObject.Find("Fish").GetComponent<Fish>();
        gameOverReasonText.SetText("");
        gameOverText.SetText("");
        timer = 0f;
        transcendAnimator = GameObject.Find("CameraFadeAlpha").GetComponent<Animator>();
        m_playAgain.SetActive(false);
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
            GameOver("You transcended in only\n" + timer + " fish seconds");
        }
        
    }

    public void GameOver(string GameOverReason)
    {
        gameIsOver = true;
        m_fish.moveSpeed = 0;
        gameOverReasonText.SetText(GameOverReason);
        if (transcended == true)
            gameOverText.SetText("Congrats");
        else if (transcended == false)
            gameOverText.SetText("Game Over");

        m_playAgain.SetActive(true);

    }
}
