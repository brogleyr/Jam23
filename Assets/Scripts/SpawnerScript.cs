using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class SpawnerScript : MonoBehaviour
{
    //Object to spawn
    public GameObject rock;

    //Spawn Boundries
    public float TopBoundry = 0;
    public float BottomBoundry = 0;
    public float RightBoundry = 0;
    public float LeftBoundry = 0;

    //Rock Count
    public float MaxRocks = 0;
    private float CurrentRocks = 0;

    //Radius around rocks where no rocks can spawn
    public float spawnRadius = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnRocks();
        
    }

    void spawnRocks()
    {
        if (CurrentRocks < MaxRocks)
        {
            var position = new Vector3(Random.Range(LeftBoundry, RightBoundry), Random.Range(BottomBoundry, TopBoundry), 0);
            Collider2D spawnCollision = Physics2D.OverlapCircle(position, spawnRadius);
            UnityEngine.Debug.Log("Trying to Spawn Rock " + CurrentRocks);
            if (spawnCollision == false)
            {
                Instantiate(rock, position, transform.rotation);
                CurrentRocks++;
                UnityEngine.Debug.Log("Spawning Rock " + CurrentRocks);
            }


        }
    }

    
}
