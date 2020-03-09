using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float ballSpeed; //the speed at which the ball itself will move
    float pillarSpeed; //the speed at which the pillar will move

    bool canMove;
    bool canGrow;

    Vector3 direction;
    float scaleSpeed;

    // Start is called before the first frame update
    void Awake()
    {
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
            other.GetComponent<Pillar>().Jump(pillarSpeed);
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
}
