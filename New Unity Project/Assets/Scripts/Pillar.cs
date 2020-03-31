using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pillar : MonoBehaviour
{
    float startPos; //starting position of pillar
    float startSpeed; //base speed of pillar
    float speed; //the speed at which the pillar will move

    bool isIdle; //checks to see if the pillar is idle. if it is waiting, it wont be moved by the script.

    bool isActive;

    Material material;

    float colourTimer;
    float colourSpeed;
    Color targetColour;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.y;
        startSpeed = 10f;
        speed = startSpeed;

        isIdle = true;
        isActive = true;

        material = GetComponent<Renderer>().material;
        material.SetColor("Color_78BD9413", new Color(0.4f, 0.213321f, 0.5643f));
        targetColour = new Color(0.4f, 0.213321f, 0.5643f);

        colourSpeed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        //if the pillar isn't currently idle, then move the pillar up
        if (!isIdle && isActive)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
            if (speed > -4f)
            {
                speed -= 0.2f; //lowers the speed over time to act like gravity
            }
        }

        //if the pillar is deactivated and is in the air, it will quickly fall down
        if (!isActive && transform.position.y > startPos)
        {
            speed = -30f;
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        }

        //if the pillar is currently idle but the start(landing/rest) position has been changed to be lower, then it will slowly move down to new position
        if (isIdle && transform.position.y > startPos)
        {
            speed = -5f;
            transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);
        }


        //if the pillar goes below its starting position, it is reset and set to idle so it will no longer be moved until prompted
        //so currently pillars won't be able to go lower than their starting position
        //can be changed to accomodate that when necessary
        if (transform.position.y < startPos)
        {
            transform.position = new Vector3(transform.position.x, startPos, transform.position.z);
            isIdle = true;
        }

        //this will change the colour over time to the target colour
        colourTimer += colourSpeed * Time.deltaTime;
        material.SetColor("Color_78BD9413", Color.Lerp(material.GetColor("Color_78BD9413"), targetColour, colourTimer));


        //changes the intensity of the colour based on position
        material.SetColor("Color_848602D4", Color.Lerp(new Color(0.8f, 0.8f, 0.8f), new Color(1.5f, 1.5f, 1.5f), (transform.position.y - startPos) / 5));
    }

    public void Jump(float newSpeed)
    {
        speed = newSpeed;
        isIdle = false;
    }

    //Pillar is set to inactive when it is near the player.
    public void SetActive(bool active)
    {
        if (active)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }
    }

    public void ChangeColour(Color colour)
    {
        targetColour = colour;
        colourTimer = 0;
    }
}
