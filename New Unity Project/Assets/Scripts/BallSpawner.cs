using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS IS FOR TESTING PURPOSES
public class BallSpawner : MonoBehaviour
{
    public Transform spawnLoc;
    public GameObject ballPrefab;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        GameObject obj = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        obj.GetComponent<Ball>().SetMove(new Vector3(1, 0, 0), 30f, Random.Range(20f, 30f));
        Destroy(obj, 5);
    }
}
