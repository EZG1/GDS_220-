using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    float ballSpeed;

    public float pillarPos;
    public float pillarSpeed;

    // Start is called before the first frame update
    void Start()
    {
        pillarPos = 8;
        pillarSpeed = 15;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Moving");
        //transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pillar")
        {
            other.GetComponent<Pillar>().NewTarget(pillarPos, pillarSpeed);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Pillar")
        {
            other.GetComponent<Pillar>().Reset();
        }
    }
}
