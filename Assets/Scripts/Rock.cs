using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private int despawnCounter = 60;
    private float despawnDistance = 150;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (despawnCounter <= 0) {
            
            Vector2 fishPosition = GameObject.FindWithTag("Fish").transform.position;
            if (Vector2.Distance(fishPosition, transform.position) > despawnDistance) {
                Destroy(gameObject);
            }
            despawnCounter = 60;
        }
        else {
            despawnCounter--;
        }
    }
}
