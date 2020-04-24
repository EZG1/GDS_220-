using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float ballSpeed; //the speed at which the ball itself will move
    public float pillarSpeed; //the speed at which the pillar will move

    public bool canMove;
    public bool canGrow;

    public bool canColourChange;
    public Color colour;

    public bool isGradient;
    public Color secondColour;
    public float gradientSpeed;
    float gradientValue;

    public Vector3 direction;
    public float scaleSpeed;

    //variable to conrtor height variation
    private int speedAlterationVariance = 10;
    private int speedAlteration = 1;
    private bool speedAlterationMovingUp = true;

    void Awake()
    {
        /*speedAlteration = Random.Range(1, 10);
        if (Random.Range(1,2) == 1)
        {
            speedAlterationMovingUp = false;
        }
        
        InvokeRepeating("Variation", 1.0f, 0.07f);*/ //removed speedAlteration for now as it made movement inconsistent
    }

    private void Start()
    {
        gradientValue = 0;
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

        if (isGradient)
        {
            colour = Color.Lerp(colour, secondColour, gradientValue += Time.deltaTime * gradientSpeed);
        }
    }

    //if the ball comes into contact with a pillar, it will trigger the pillar to move
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Pillar>())
        {
            other.GetComponent<Pillar>().Jump(pillarSpeed); // + speedAlteration  //removed speedAlteration for now as it made movement inconsistent
        }

        if (canColourChange && other.GetComponent<Pillar>())
        {
            other.GetComponent<Pillar>().ChangeColour(colour);
        }
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
