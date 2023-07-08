using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    
    public LineRenderer lineRenderer;
    private bool attached = false;
    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.sortingOrder = 1;
        lineRenderer.material = new Material (Shader.Find ("Sprites/Default"));
        lineRenderer.material.color = Color.black;

        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update() {
        if (attached)
        {
            transform.position = GameObject.Find("Fish").GetComponentInChildren<Transform>().transform.position;
        }
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.parent.position);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Fish") {
            attached = true;
            transform.GetChild(0).gameObject.SetActive(false);
            transform.parent.gameObject.GetComponent<BoatMove>().SetAttached(true);
            scoreManager.OnTheLine();
        }
    }
}
