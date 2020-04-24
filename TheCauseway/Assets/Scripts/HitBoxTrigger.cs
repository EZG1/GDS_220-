using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxTrigger : MonoBehaviour
{
    public delegate void OnStart();
    public static OnStart start;

    // Start is called before the first frame update
    void Start()
    {
        start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //removed do to movement change
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            start();

            Destroy(gameObject);
        }
    }
}
