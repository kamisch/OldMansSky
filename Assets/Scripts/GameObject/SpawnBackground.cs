using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpawnBackground : MonoBehaviour {

	public GameObject[]tiles;
    int BackgroundIndex = 0; // variable for changing colors
    private Transform playerTransform;
	private float spawnX = -6f;
	private float tilesLength = 300f;
	private int amnTilesOnScreen = 7;

    // initializing variables to remove
    private float safeZone = 230;
    private List<GameObject> activeTiles = new List<GameObject>();


	// Use this for initialization
	private void Start () {
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;
        
        // spawn the initial bakcground
		for (int i = 0; i < amnTilesOnScreen; i++) {
			SpawnTile ();
		}
	}
	
	// Update is called once per frame
	private void Update () {
		if (-playerTransform.position.x - safeZone > (spawnX - amnTilesOnScreen * tilesLength)) {
			SpawnTile ();
            DeleteTile();
		}
        //DeleteTile();
	}

	private void SpawnTile (){

        if (spawnX > 1000 & spawnX <= 6000)
        {
            BackgroundIndex = 1;
        }
        else if (spawnX > 6000 & spawnX <= 10000)
        {
            BackgroundIndex = 2;
        }
        else if (spawnX > 10000)
        {
            BackgroundIndex = 3;
        } 
        else
        {
            BackgroundIndex = 0;
        }

        GameObject go;
		go = Instantiate (tiles[BackgroundIndex]) as GameObject;

        // sets the material color
       

        // sets position 
        go.transform.SetParent (transform);
		Vector3 SpawnPosi = new Vector3 (-spawnX, 40, 0);

        go.transform.position = SpawnPosi;

		spawnX += tilesLength;

        if (go != null)
        {
          activeTiles.Add(go);
        }
        
	}

    private void DeleteTile() // delete tiles after passing them, so game runs smoothly
    {
            Destroy(activeTiles[0]);
            activeTiles.RemoveAt(0);
        
       
    }
}
