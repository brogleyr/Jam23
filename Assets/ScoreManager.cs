using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI comboUI;
    public TextMeshProUGUI scoreUI;
    
    private int score = 0;
    private int combo = 0;
    private int onTheLine = 0;
    private float comboCoolDownStart = 5;
    private float comboCooldown = 5; //seconds

    // Update is called once per frame
    void Update()
    {
        if (comboCooldown <= 0) {
            combo = 0;
            comboCooldown = comboCoolDownStart;
            UpdateUI();
        }
        
        comboCooldown -= Time.deltaTime;
    }

    private void ComboUp() {
        combo++;
        comboCooldown = comboCoolDownStart;
    }

    public void OnTheLine() {
        onTheLine++;
    }

    public void OffTheLine() {
        onTheLine--;
    }
    

    public void BoatCrash(Transform crashedBoat) {
        ComboUp();
        onTheLine = 0;
        GameObject[] boats = GameObject.FindGameObjectsWithTag("Boat");
        foreach (GameObject boat in boats) {
            if (boat.GetComponent<BoatMove>().GetAttached()) {
                onTheLine++;
            }
        }
        score += combo * onTheLine;
        OffTheLine();
        UpdateUI();
    }

    private void UpdateUI() {
        comboUI.text = "COMBO:\nx" + combo.ToString();
        scoreUI.text = score.ToString();
    }
}
