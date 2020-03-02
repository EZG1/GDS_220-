using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float ballSpeed; //the speed at which the ball itself will move

    //public float pillarPos; //the position we want the pillar to move *NOT IN USE AT THE MOMENT*
    public float pillarSpeed; //the speed at which the pillar will move

    public bool isTest; //used for testing purposes.

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //pillarPos = 8;
        pillarSpeed = 20;

        ballSpeed = 30;

        rb = GetComponent<Rigidbody>();

        if (!isTest)
        {
            Destroy(gameObject, 5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isTest)
        {
            //moves the ball automatically
            transform.position = new Vector3(transform.position.x + ballSpeed * Time.deltaTime, transform.position.y, transform.position.z);
        }
    }

    //if the ball comes into contact with a pillar, it will trigger the pillar to move
    private void OnTriggerEnter(Collider other)
    {
        /*if (other.gameObject.tag == "Pillar")
        {
            other.GetComponent<Pillar>().NewTarget(pillarPos, pillarSpeed);
        }*/

        if (other.gameObject.tag == "Pillar")
        {
            other.GetComponent<Pillar>().Jump(pillarSpeed);
        }
    }

    //This resets the pillar wants the ball leaves the pillar's collision box.
    //*NOT IN USE AT THE MOMENT*
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Pillar")
        {
            other.GetComponent<Pillar>().Reset();
        }
    }
}
