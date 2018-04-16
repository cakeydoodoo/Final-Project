using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour {
    public GameObject enemyPrefab;
    public float spawnTime;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("Spawn" , spawnTime, 2);
    }
	
	// Update is called once per frame
	void Update ()
    {


	}

    void Spawn()
    {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }
}
