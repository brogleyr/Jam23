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
    void Start()
    {
        //Find the barrel of your gun assuming its the first child object
        firePoint = this.transform.GetChild(0).transform;
    }

    //Shooting bullet logic
    public void Shoot()
    {
        //Spawn Bullet
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //If object has a bullet firing animation find it and play it
    }

}
