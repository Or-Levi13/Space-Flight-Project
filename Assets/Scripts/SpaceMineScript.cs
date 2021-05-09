using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMineScript : MonoBehaviour
{
    public Transform[] playerShip;
    public float speed = 15f;
    int currentWayPoint;
    Vector3 target, moveDirection;
    public float spawnRange;
    public float amountToSpawn;
    private Vector3 spawnPoint;
    public GameObject missile;
   
    public float startSafeRange;
    private List<GameObject> objectsToPlace = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        DrawField();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        target = playerShip[currentWayPoint].position;
        moveDirection = target - transform.position;
        if (moveDirection.magnitude < 1)
        {
            currentWayPoint = ++currentWayPoint % playerShip.Length;
        }
        GetComponent<Rigidbody>().velocity = moveDirection.normalized * speed;
    }

    public void PickSpawnPoint()
    {
        spawnPoint = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f));

        if (spawnPoint.magnitude > 1)
        {
            spawnPoint.Normalize();
        }

        spawnPoint *= spawnRange;
    }

    private void OnTriggerEnter(Collider other)
    {


    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("LeftWorld");
        DrawField();
    }

    private void DrawField()
    {
        Debug.Log("Asteroid field created");

        for (int i = 0; i < amountToSpawn; i++)
        {
            PickSpawnPoint();

            //pick new spawn point if too close to player start
            while (Vector3.Distance(spawnPoint, Vector3.zero) < startSafeRange)
            {
                PickSpawnPoint();
            }

            objectsToPlace.Add(Instantiate(missile, spawnPoint, Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f))));
            objectsToPlace[i].transform.parent = this.transform;
        }
        
    }
   
}
