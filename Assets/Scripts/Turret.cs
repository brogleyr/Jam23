using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public bool seeEnemy = false;
    bool isShooting = false;
    Shooter shooter;
    CircleCollider2D collider;
    Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CircleCollider2D>();
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        shooter = GetComponent<Shooter>();
    }

    IEnumerator FireContinuously()
    {
        isShooting = true;
        yield return new WaitForSeconds(1 / shooter.rateOfFire);
        shooter.Shoot();
        isShooting = false;
    }

     void OnTriggerEnter2D(Collider2D other)
     {
        Debug.Log("I see" + other.name);
        if (other.gameObject.tag == "Mouth")
            seeEnemy = true;
        
     }
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("I don't see" + other.name);
        if (other.gameObject.tag == "Mouth")
            seeEnemy = false;

    }

    // Update is called once per frame
    void Update()
    {
        collider.radius = camera.orthographicSize;
        while (seeEnemy && !isShooting)
        {
            StartCoroutine(FireContinuously());
        }
        
    }
}
