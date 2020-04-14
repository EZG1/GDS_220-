using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public GameObject fader;
    private Animator thisAnimation;

    // Start is called before the first frame update
    void Start()
    {
        thisAnimation = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("trying the fade");
            fader.GetComponent<OVRScreenFade>().FadeOut(); 
        }*/

        // transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f * Time.deltaTime, transform.position.z);
    }
}
