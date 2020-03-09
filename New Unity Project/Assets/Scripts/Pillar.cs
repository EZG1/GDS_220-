﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    float startPos; //starting position of pillar
    float startSpeed; //base speed of pillar
    public float targetPos; //the target position that the pillar wants to move to *NOT IN USE AT THE MOMENT*
    public float speed; //the speed at which the pillar will move

    bool isIdle; //checks to see if the pillar is idle. if it is waiting, it wont be moved by the script.

    bool isActive;



    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.y;
        startSpeed = 10f;
        targetPos = startPos;
        speed = startSpeed;

        isIdle = true;
        isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if the pillar isn't currently idle, then move the pillar up
        if (!isIdle && isActive)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            speed -= 0.2f; //lowers the speed over time to act like gravity
        }

        //if the pillar is deactivated and is in the air, it will quickly fall down
        if (!isActive && transform.position.y > startPos)
        {
            speed = -30f;
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        }

        //if the pillar is currently idle but the start(landing/rest) position has been changed to be lower, then it will slowly move down to new position
        if (isIdle && transform.position.y > startPos)
        {
            speed = -5f;
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        }


        //if the pillar goes below its starting position, it is reset and set to idle so it will no longer be moved until prompted
        //so currently pillars won't be able to go lower than their starting position
        //can be changed to accomodate that when necessary
        if (transform.position.y < startPos)
        {
            transform.position = new Vector3(transform.position.x, startPos, transform.position.z);
            isIdle = true;
        }
    }

    public void Jump(float newSpeed)
    {
        speed = newSpeed;
        isIdle = false;
    }

    public void SetActive(bool active)
    {
        if (active)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }
    }

    public void SetPosition(float position)
    {
        startPos = position;
    }
}
