using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMaker : MonoBehaviour
{
    private float currentTimeBtwSpawns;
    public float TimeBtwSpawns = 0.1f;

    public GameObject wave;

    private void Update()
    {
        if (currentTimeBtwSpawns <= 0)
        {
            Instantiate(wave, transform.position, transform.rotation);
            currentTimeBtwSpawns = TimeBtwSpawns;
        }
        else
        {
            currentTimeBtwSpawns -= Time.deltaTime;
        }
    }
}
