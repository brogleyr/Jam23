using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    //can you see the enemy
    bool seeEnemy = false;
    //how fast can you turn
    public float rotationSpeed = 90;
    //are you shooting?
    bool isShooting = false;
    //shooter scipt
    Shooter shooter;
    //the collider
    CircleCollider2D m_CirlceCollider2D;
    //the main camera
    Camera m_camera;
    //target of turret
    Transform target;
    //Alligns assets incase their roation is off
    public float rotationModifier = 45;
    // Start is called before the first frame update
    void Start()
    {
        m_CirlceCollider2D = GetComponent<CircleCollider2D>();
        m_camera = GameObject.Find("Main Camera").GetComponent<Camera>();
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
        if (other.gameObject.CompareTag("Fish") == true)
        {
            seeEnemy = true;
            target = other.transform;
        }
            
        
     }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fish") == true)
        {
            seeEnemy = false;
        }
           

    }

    // Update is called once per frame
    void Update()
    {
        if (seeEnemy)
        {
            Rotate(target);
        }
            
        m_CirlceCollider2D.radius = m_camera.orthographicSize;
        while (seeEnemy && !isShooting)
        {
            StartCoroutine(FireContinuously());
        }
    }
    void Rotate(Transform target)
    {
        {
            Vector3 vectorToTarget = target.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotationSpeed);
        }
    }

}
