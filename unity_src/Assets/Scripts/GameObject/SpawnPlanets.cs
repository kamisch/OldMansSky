using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class SpawnPlanets : MonoBehaviour {
    public GameObject[] planets;
    public GameObject[] Items;

    private Transform playerTransform;
    private float spawnX;
 
    private float planetLength = 50f;
    private int amntPlanetsOnScreen =7;
    private int randomX;
    private int randomX1;
    // rock varibales
    private float spawnRockX;
    private float randomRockX;
    private float randomRockX1;
    // sun variables
    private float spawnSunX;
    private int randomSunX;
    private int randomSunX1;

    private int spawnPosition; // set Update method when to spawn

    // initializing variables to remove
    private float safeZone = 10;
    private List<GameObject> activePlanet = new List<GameObject>();
    private List<GameObject> activeSun = new List<GameObject>();
    private List<GameObject> activeRocks = new List<GameObject>();
    private List<GameObject> activeItems = new List<GameObject>();

    private void Start()
    {
        // give range to variables 
        spawnX = 300;
        randomX = 0; // spawn random position planet
        randomX1 = 0;


        spawnRockX = 200;
        randomRockX = 0; // spawn random position rocks
        randomRockX1 = 0;


        spawnSunX = 700;
        randomSunX =0 ;
        randomSunX1 = 0;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < amntPlanetsOnScreen; i++)
        {
           
            SpawnRandomPlanets();
            SpawnRandomRocks();
            SpawnRandomRocks();
            SpawnRandomSun();

           
        }

    }
    
    private void LateUpdate()
    {
        if (-playerTransform.position.x > (spawnX - amntPlanetsOnScreen * planetLength))
        {

            for (int i = 0; i < 7; i++)
            {
                SpawnRandomPlanets();
                SpawnRandomPlanets();
                SpawnRandomRocks();
                SpawnRandomRocks();
                SpawnRandomRocks();
                SpawnRandomSun();

            }
            if (-playerTransform.position.x > 10000) // more planets getting spawned in late game
            {
                SpawnRandomRocks();
                SpawnRandomRocks();
                SpawnRandomRocks();
                SpawnRandomPlanets();
                SpawnRandomPlanets();
                SpawnRandomSun();
            }

            if (-playerTransform.position.x > 1000000)
            {
                SpawnRandomRocks();
                SpawnRandomRocks();
                SpawnRandomRocks();
                SpawnRandomPlanets();
                SpawnRandomPlanets();
                SpawnRandomSun();
            }
        }

        
    }
    
    private void SpawnRandomPlanets()
    {
        float spawnY = Random.Range(-30, 100);
        GameObject planet;
        int randomPlanets = Random.Range(0, 4);

        planet = Instantiate(planets[randomPlanets]) as GameObject;

        planet.transform.SetParent(transform);
        if ((-spawnX - playerTransform.position.x) < 20) // make sure planet and player don't overlap
        {
            spawnX += 100;
        }
        Vector3 SpawnPosi = new Vector3(-spawnX, spawnY, 0);
        planet.transform.position = SpawnPosi;

        if (randomPlanets == 0)  // generates rocket fuel near Earth;
        {
            SpawnRandomItems(planet, 0);
        }
        else if (randomPlanets == 2) // genreate bonus near Jupiter;
        {
            SpawnRandomItems(planet, 1);
        }

        spawnX = Random.Range(randomX, randomX1);

        int randomDistance = Random.Range(50, 200);
        // update for new x position
        randomX += randomDistance;
        randomX1 += randomDistance;

        //
        activePlanet.Add(planet);
    }

    private void SpawnRandomRocks()
    {
        float spawnY = Random.Range(-30, 100);
        GameObject rock;
        rock = Instantiate(planets[5]) as GameObject;

        rock.transform.SetParent(transform);
        if ((-spawnSunX - playerTransform.position.x) < 20) // make sure player and sun dont overlap
        {
            spawnSunX += 100;
        }

        Vector3 SpawnPosi = new Vector3(-spawnRockX, spawnY, 0);
        rock.transform.position = SpawnPosi;

        spawnRockX = Random.Range(randomRockX, randomRockX1);
        int randomDistance = Random.Range(10, 200);
        randomRockX += randomDistance;
        randomRockX1 += randomDistance;

        activeRocks.Add(rock);
    }

    private void SpawnRandomSun()
    {
        float spawnY = Random.Range(-20, 90);
        GameObject sun;
        sun = Instantiate(planets[4]) as GameObject;

        sun.transform.SetParent(transform);
        if ((-spawnSunX - playerTransform.position.x) < 20) // make sure player and sun dont overlap
        {
            spawnSunX += 100;
        }
        Vector3 SpawnPosi = new Vector3(-spawnSunX, spawnY, 0);
        sun.transform.position = SpawnPosi;

        SpawnRandomItems(sun, 2); // spawn health item near sun, high risk high reward

        spawnSunX = Random.Range(randomSunX, randomSunX1);

        int randomDistance = Random.Range(800, 1000);
        randomSunX += randomDistance;
        randomSunX1 += randomDistance;

        activeSun.Add(sun);


    }


    private void SpawnRandomItems(GameObject planets,int num)
    {
        float spawnY = Random.Range(-30, 100);
        GameObject Item1;
        Item1 = Instantiate(Items[num]) as GameObject;

        float randomPosition = Random.Range(50, 70);
        float randomY = Random.Range(-50, 50);

        Item1.transform.SetParent(transform);
       
        Vector3 SpawnPosi = new Vector3(planets.transform.position.x + randomPosition , planets.transform.position.y + randomY, 0);
        Item1.transform.position = SpawnPosi;

        spawnX = Random.Range(randomX, randomX1);

        int randomDistance = Random.Range(50, 200);
        // update for new x position
        randomX += randomDistance;
        randomX1 += randomDistance;

        activeItems.Add(Item1);
    }


 
}
