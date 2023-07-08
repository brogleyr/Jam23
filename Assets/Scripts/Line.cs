using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    
    public LineRenderer lineRenderer;
    private bool attached = false;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.sortingOrder = 1;
        lineRenderer.material = new Material (Shader.Find ("Sprites/Default"));
        lineRenderer.material.color = Color.black;
    }

    // Update is called once per frame
    void Update() {
        if (attached) {
            transform.position = GameObject.Find("Fish").transform.position;
        }
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.parent.position);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Fish") {
            attached = true;
            GetComponent<SpriteRenderer>().enabled = false;
            transform.parent.gameObject.GetComponent<Fisherman>().SetAttached(true);
        }
    }
}
