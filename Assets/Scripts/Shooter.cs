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
    private BoatSFX boatSfx;

    void Start()
    {
        //Find the barrel of your gun assuming its the first child object
        firePoint = this.transform.GetChild(0).transform;
        m_gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        boatSfx = GetComponentInChildren<BoatSFX>();
    }

    //Shooting bullet logic
    public void Shoot()
    {
        if (m_gameManager.gameIsOver == false && firePoint != null)
        {
            //Spawn Bullet
            if (firePoint != null)
            {
                Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                boatSfx.PlayHarpoonSound();
                //If object has a bullet firing animation find it and play it
                //play animation :)
            }

        }

    }
   
}
