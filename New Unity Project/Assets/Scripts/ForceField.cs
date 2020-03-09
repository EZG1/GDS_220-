using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Deactivates the pillar once the player is near so that the player won't be affected by the movement of the pillars
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Pillar>())
        {
            other.gameObject.GetComponent<Pillar>().SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Pillar>())
        {
            other.gameObject.GetComponent<Pillar>().SetActive(true);
        }
    }
}
