using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    float startPos;
    float startSpeed;
    public float targetPos;
    public float speed;

    bool isWaiting;



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
        /*if (Mathf.Abs(transform.position.y - targetPos) > 0.1)
        {
            Debug.Log("ASD");
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, targetPos, transform.position.z), speed * Time.deltaTime);
        }*/

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

        if (Input.GetKeyDown("e"))
        {
            speed = 20f;
            isWaiting = false;
        }
    }

    public void NewTarget(float newPos, float newSpeed)
    {/*
        targetPos = newPos;
        speed = newSpeed;*/

        speed = newSpeed;
        isWaiting = false;
    }

    public void Reset()
    {/*
        targetPos = startPos;
        speed = startSpeed;*/
    }
}
