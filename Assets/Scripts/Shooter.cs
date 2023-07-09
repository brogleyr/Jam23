using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    //The barrel of the gun
    private Transform firePoint;
    //The type of bullet fired
    public GameObject bulletPrefab;
    public float rateOfFire = 1;
    // Start is called before the first frame update
    private GameManager m_gameManager;
    void Start()
    {
        //Find the barrel of your gun assuming its the first child object
        firePoint = this.transform.GetChild(0).transform;
        m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    //Shooting bullet logic
    public void Shoot()
    {
        if (m_gameManager.gameIsOver!)
        {
            //Spawn Bullet
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            //If object has a bullet firing animation find it and play it
            //play animation :)
        }

    }

}
