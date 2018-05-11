using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour {
    public GameObject enemyPrefab;
    public float spawnTime;
    Vector3 direction;
    //Transform rotation;

	// Use this for initialization

    void Start ()
    {
                InvokeRepeating("Spawn" , spawnTime, 2);

    }
	
	// Update is called once per frame
	void Update ()
    {
        direction = new Vector3(Random.Range(-180, 180), Random.Range(-180, 180), Random.Range(-180, 180));
        //rotation.rotation = Quaternion.Euler(0, Random.Range(-180, 180), 0);
	}

    void Spawn()
    {
        Instantiate(enemyPrefab, transform.position + direction,Quaternion.identity/* rotation.rotation*/);
    }
}
