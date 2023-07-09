using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public float lifetime = 2;
    private float y;
    public float scalefactor = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        y = transform.localScale.y;
        Destroy(this.gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(1, y, 1);
        y = y + (scalefactor/10);
    }
}
