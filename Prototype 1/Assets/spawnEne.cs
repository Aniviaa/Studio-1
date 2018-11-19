using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEne : MonoBehaviour {

    public GameObject plane;
    public GameObject enemy;
    Mesh planeMesh;
    Bounds bounds;

    float minX;
    float minZ;

    public float spawnTimer;
    // Use this for initialization
    void Start ()
    {
        planeMesh = plane.GetComponent<MeshFilter>().mesh;
        bounds = planeMesh.bounds;

        minX = plane.transform.position.x - plane.transform.localScale.x * bounds.size.x * 0.5f;
        minZ = plane.transform.position.z - plane.transform.localScale.z * bounds.size.z * 0.5f;
    }
	
	// Update is called once per frame
	void Update () {

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= 4)
        {
            Vector3 enemyVector = new Vector3(Random.Range(minX, -minX),
                     plane.transform.position.y,
                     Random.Range(minZ, -minZ));

            Debug.Log(enemyVector);

            Instantiate(enemy, enemyVector, Quaternion.identity);
            spawnTimer = 0;
        }

    }
}
