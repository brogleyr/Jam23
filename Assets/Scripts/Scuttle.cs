using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scuttle : MonoBehaviour
{

    private ScoreManager scoreManager;
    public Animator animator;
    public BoatSFX boatSfx;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        boatSfx = GetComponentInChildren<BoatSFX>();
    }


    public void ScuttleBoat() {
        scoreManager.BoatCrash(transform);
        animator.SetTrigger("BoatDestroyed");
        if (boatSfx) {
            boatSfx.PlayScuttleSound();
        }

        foreach (Transform child in transform) {
            if (child.name != "Sprite" && child.name != "BoatSFX") {
                Destroy(child.gameObject);
            }
        }

        Destroy(gameObject, 1f);
    }
}
