using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS IS FOR TESTING PURPOSES
public class BallSpawner : MonoBehaviour
{
    public Transform spawnLoc;
    public GameObject ballPrefab;

    /*
    private int speedAlterationVariance = 5;
    private int speedAlteration = 1;
    private bool speedAlterationMovingUp = true;
    private int speedAlteration2;
    */

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1.0f, 3.0f);
       /* InvokeRepeating("UpdateVariation", 1.0f, 0.3f);
        InvokeRepeating("Variation", 1.0f, 0.15f);
        */
    }

    // Update is called once per frame
    void Update()
    {
    }

    void Spawn()
    {
        GameObject obj = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        obj.GetComponent<Ball>().SetMove(new Vector3(1, 0, 0), 40f, 10f);
        Destroy(obj, 5);
    }

   /* private void Variation()
    {
        if (speedAlterationMovingUp == true)
        {
            if (speedAlteration >= speedAlterationVariance)
            {
                speedAlterationMovingUp = false;
            }
            speedAlteration += 1;

        }
        else
        {
            if (speedAlteration <= 1)
            {
                speedAlterationMovingUp = true;
            }
            speedAlteration -= 1;
        }
    }

    private void UpdateVariation()
    {
        speedAlteration2 = Random.Range(1, 10);
    } */
}
