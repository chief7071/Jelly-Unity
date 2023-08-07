using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawners : MonoBehaviour
{
    public int numberOfCoinsToSpawn;
    public GameObject prefab;
    public float timeBetweenSpawns;

    private float timeToNextSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeToNextSpawn = timeBetweenSpawns;
    }
    void Spawn()
    {
        for(int i=0; i<30; i++)
         Instantiate(prefab, new Vector2(-10+0.7f*i,13),Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {


        // Check if it's time to spawn a coin
        if (timeToNextSpawn <= 0 && numberOfCoinsToSpawn > 0)
        {
            // Spawn the coin prefab
            Instantiate(prefab, transform.position, Quaternion.identity);

            // Decrease the number of coins left to spawn
            numberOfCoinsToSpawn--;

            Spawn();
            timeToNextSpawn = timeBetweenSpawns;
        }

        // Decrease the time to the next spawn
        timeToNextSpawn -= Time.deltaTime;

        // Check if there are still coins to spawn
        if (numberOfCoinsToSpawn <=0.0f)
        {
            // Disable the script if all coins are spawned
            enabled = false;
        }
    }
}