using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    private TextMeshProUGUI comboUI;
    private TextMeshProUGUI scoreUI;
    
    private int score = 0;
    private int combo = 0;
    //private int onTheLine = 0;
    private float comboCoolDownStart = 5;
    private float comboCooldown = 5; //seconds
    private float maxComboFontSize = 42;
    private float minComboFontSize = 18;

    void Start() {
        comboUI = GameObject.Find("ComboCounter").GetComponent<TextMeshProUGUI>();
        scoreUI = GameObject.Find("ScoreCounter").GetComponent<TextMeshProUGUI>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (comboCooldown <= 0) {
            ComboBreak();
            comboCooldown = comboCoolDownStart;
        }
        comboCooldown -= Time.deltaTime;
        UpdateUI();
    }

    private void ComboUp() {
        combo++;
        comboCooldown = comboCoolDownStart;
    }

    public void ComboBreak() {
        combo = 0;
    }

    public void BoatCrash(Transform crashedBoat) {
        ComboUp();
        int boatPoints = 100;
        if (crashedBoat.gameObject.GetComponent<NavyBoat>() != null) {
            boatPoints = 500;
        }
        else if (crashedBoat.gameObject.GetComponent<Turret>()) {
            boatPoints = 200;
        }


        score += combo * boatPoints;
    }

    private void UpdateUI() {
        float comboCooldownPercent = Mathf.InverseLerp(0, comboCoolDownStart, comboCooldown);
        if (combo == 0) {
            comboUI.fontSize = minComboFontSize;
        }
        else {
            comboUI.fontSize = Mathf.Lerp(minComboFontSize, maxComboFontSize, comboCooldownPercent);
        }
        comboUI.text = "COMBO:\nx" + combo.ToString();
        scoreUI.text = score.ToString();
    }

    public int GetCombo() {
        return combo;
    }
}
