using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is a simple pillar will only move towards a position that is set
//this won't be affected by other movement like normal pillars
public class SimplePillar : MonoBehaviour
{
    //during the game, targetPos can be changed and the pillar will move automatically to that position
    float targetPos;
    float speed;

    //this can be altered in the inspector so we can place initial values in the scene
    //this can then be used to set a new targetPos with the SetPosition function
    public float manualPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        targetPos = transform.position.y;
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        float difference;

        difference = targetPos - transform.position.y;

        if (difference > 0.1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        }
        else if (difference < -0.1)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, targetPos, transform.position.z);
        }
        
    }

    public void SetPosition(float position)
    {
        targetPos = position;
    }
}
