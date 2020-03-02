using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    float startPos; //starting position of pillar
    float startSpeed; //base speed of pillar
    public float targetPos; //the target position that the pillar wants to move to *NOT IN USE AT THE MOMENT*
    public float speed; //the speed at which the pillar will move

    bool isWaiting; //checks to see if the pillar is waiting. if it is waiting, it wont be moved by the script.



    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.y;
        startSpeed = 10f;
        targetPos = startPos;
        speed = startSpeed;

        isWaiting = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if the pillar's position isn't near the target position, then move towards it.
        //*NOT IN USE AT THE MOMENT*
        /*if (Mathf.Abs(transform.position.y - targetPos) > 0.1)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, targetPos, transform.position.z), speed * Time.deltaTime);
        }*/

        //if the pillar isn't currently waiting, then move the pillar up
        if (!isWaiting)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            speed -= 0.2f;
        }

        if (transform.position.y < startPos)
        {
            transform.position = new Vector3(transform.position.x, startPos, transform.position.z);
            isWaiting = true;
        }
    }

    public void NewTarget(float newPos, float newSpeed)
    {
        targetPos = newPos;
        speed = newSpeed;

        
    }

    public void Jump(float newSpeed)
    {
        speed = newSpeed;
        isWaiting = false;
    }

    public void Reset()
    {/*
        targetPos = startPos;
        speed = startSpeed;*/
    }
}
