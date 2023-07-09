using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scuttle : MonoBehaviour
{

    private ScoreManager scoreManager;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }


    public void ScuttleBoat() {
        scoreManager.BoatCrash(transform);
        animator.SetTrigger("BoatDestroyed");

        foreach (Transform child in transform) {
            if (child.name != "Sprite") {
                Destroy(child.gameObject);
            } 
        }

        Destroy(gameObject, 1f);
    }
}
