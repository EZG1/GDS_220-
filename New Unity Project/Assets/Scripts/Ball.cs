using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballSpeed; //the speed at which the ball itself will move
    public float pillarSpeed; //the speed at which the pillar will move

    public bool canMove;
    public bool canGrow;

    public Vector3 direction;
    public float scaleSpeed;

    //variable to conrtor height variation
    private int speedAlterationVariance = 10;
    private int speedAlteration = 1;
    private bool speedAlterationMovingUp = true;

    // Start is called before the first frame update
    void Awake()
    {
        speedAlteration = Random.Range(1, 10);
        if (Random.Range(1,2) == 1)
        {
            speedAlterationMovingUp = false;
        }
        
        InvokeRepeating("Variation", 1.0f, 0.07f);
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            transform.position += direction.normalized * ballSpeed * Time.deltaTime;
        }

        if (canGrow)
        {
            transform.localScale += new Vector3(scaleSpeed, scaleSpeed, scaleSpeed) * Time.deltaTime;
        }
    }

    //if the ball comes into contact with a pillar, it will trigger the pillar to move
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Pillar>())
        {
            other.GetComponent<Pillar>().Jump(pillarSpeed + speedAlteration);
        }
    }

    private void OnTriggerExit(Collider other)
    {

    }

    //when a ball is instantiated, set these 2 functions if you want the ball to move or increase in size, or both.
    public void SetMove(Vector3 newDirection, float newBallSpeed, float newPillarSpeed)
    {
        canMove = true;
        direction = newDirection;
        ballSpeed = newBallSpeed;
        pillarSpeed = newPillarSpeed;
    }

    public void SetScale(float newScaleSpeed, float newPillarSpeed)
    {
        canGrow = true;
        scaleSpeed = newScaleSpeed;
        pillarSpeed = newPillarSpeed;
    }


    //change variation
    private void Variation()
    {
        if (speedAlterationMovingUp == true)
        {
            if (speedAlteration >= speedAlterationVariance)
            {
                speedAlterationMovingUp = false;
            }
            speedAlteration += 2;

        }
        else
        {
            if (speedAlteration <= 1)
            {
                speedAlterationMovingUp = true;
            }
            speedAlteration -= 2;
        }
    }

}
