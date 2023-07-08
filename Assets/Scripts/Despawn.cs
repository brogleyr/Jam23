using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour
{
    public int despawnCounter = 60;
    public float despawnDistance = 800;

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
