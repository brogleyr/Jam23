using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BoatCrash(GameObject boat) {
        score++;
        Debug.Log("Score: " + score);
        Destroy(boat);
    }
}
