﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public Transform spawnLoc;
    public GameObject ballPrefab;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1.0f, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        Debug.Log("ASD");
        Instantiate(ballPrefab, spawnLoc);
    }
}
