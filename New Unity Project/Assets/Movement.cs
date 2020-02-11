using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public Text pressText1;
    public Text pressText2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move forward if button is pressed
        if (OVRInput.Get(OVRInput.Button.One) == true)
        {
            transform.position += new Vector3(0,0,1);
            pressText1.text = "You have pressed the button";
        }
        else
        {
            pressText1.text = "You have NOT pressed the button";
        }

        //if trigger is used reset location
        if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) == true)
        {
            this.transform.position =  new Vector3(0, 5, 0);
            pressText2.text = "You have pressed the trigger";
        }
        else
        {
            pressText2.text = "You have NOT pressed the trigger";
        }

        /*if Input.GetButtonDown(KeyCode.Space)
         {
            print(yes);
         }*/
    }
}
