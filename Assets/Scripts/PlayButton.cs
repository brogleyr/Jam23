using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public string gotoScene;
    public void PlayGame()
    {
        SceneManager.LoadScene(gotoScene);
        //SceneManager.LoadScene("Nick");
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
