using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is used to manually move certain pillars once a player has entered a collision box
public class PillarTrigger : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform ballLoc;

    public List<GameObject> pillars;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            for (int i = 0; i < pillars.Count; i++)
            {
                if (pillars[i].GetComponent<SimplePillar>())
                {
                    pillars[i].GetComponent<SimplePillar>().SetPosition(pillars[i].GetComponent<SimplePillar>().manualPosition);
                }
            }

            GameObject obj = Instantiate(ballPrefab, ballLoc.position, Quaternion.identity);
            obj.GetComponent<Ball>().SetScale(50f, 30f);
            Destroy(obj, 3);
        }
    }
}
