using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testfall : MonoBehaviour
{
    bool things = false;
    bool stuff = false;
    float fallSpeed = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(stuff == false && things == false)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - fallSpeed, transform.position.z);
        }
 
    }
}
