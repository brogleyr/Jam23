using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletprefab;

    // Start is called before the first frame update
    void Start()
    {
        firepoint = this.transform.GetChild(0).transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Shoot();
        }

    }

    //shooting bullet logic
    void Shoot()
    {
        Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
    }

}
