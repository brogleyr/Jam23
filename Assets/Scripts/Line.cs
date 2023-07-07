using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    
    public LineRenderer lr;
    private bool attached = false;

    // Start is called before the first frame update
    void Start()
    {
        lr.sortingOrder = 1;
        lr.material = new Material (Shader.Find ("Sprites/Default"));
        lr.material.color = Color.black; 
    }

    // Update is called once per frame
    void Update() {
        if (attached) {
            transform.position = GameObject.Find("Fish").transform.position;
        }
        lr.SetPosition(0, transform.position);
        lr.SetPosition(1, transform.parent.position);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Fish") {
            attached = true;
        }
    }

}
