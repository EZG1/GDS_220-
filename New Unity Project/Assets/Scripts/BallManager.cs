using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//In the inspector of the BallManager object (under the Audio object) you can add entries to it and make more cues for when and where the ball will spawn.
//To add more cues, increase the size of the "Manager" list and then you can manually edit the values as desired.

[System.Serializable]
public struct ScalingDetails
{
    [Tooltip("Enables scaling functionality")]
    public bool CanGrow;

    [Tooltip("The speed at which the ball will scale")]
    public float GrowSpeed;
}

[System.Serializable]
public struct MovementDetails
{
    [Tooltip("Enables movement")]
    public bool CanMove;

    [Tooltip("The speed at which the ball will move")]
    public float BallSpeed;

    [Tooltip("Vector of intended direction")]
    public Vector3 Direction;
}

[System.Serializable]
public struct ColourDetails
{
    [Tooltip("Enables colour changing")]
    public bool ColourChange;

    [Tooltip("The colour that it will change to")]
    public Color Colour;
}

[System.Serializable]
public struct BallData
{
    [Tooltip("The name of this entry")]
    public string Description;

    [Tooltip("Which spawner the ball will spawn at" +
        "\n6 is top-left, 7 is top-middle, 8 is top-right " +
        "\n3 is middle-left, 4 is middle, 5 is middle-right" +
        "\n0 is bottom-left, 1 is bottom-middle, 2 is bottom-right")]
    public int SpawnIndex;

    [Tooltip("This is when (in seconds) the ball will spawn")]
    public float SpawnCue;

    [Tooltip("The starting size of the ball \n5 is the normal size")]
    public float InitialScale;

    [Tooltip("Movement Details")]
    public MovementDetails Movement;

    [Tooltip("Scaling Details")]
    public ScalingDetails Scaling;

    [Tooltip("Colour Details")]
    public ColourDetails Colouring;

    [Tooltip("The speed at which affected pillars will move up")]
    public float PillarSpeed;

    [Tooltip("The amount of time (in seconds) it takes for the ball to disappear")]
    public float DeathTime;
}

public class BallManager : MonoBehaviour
{
    public GameObject ballPrefab;

    public List<Transform> spawners = new List<Transform>();

    public List<BallData> manager = new List<BallData>();

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = transform.parent.GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    //This goes through all the entries in the Ball Manager script and then spawns the ball according to the values
    void Update()
    {
        //Debug.Log(audioSource.time);

        for (int i = 0; i < manager.Count; i++)
        {
            if (manager[i].SpawnCue - audioSource.time < 0 && manager[i].SpawnCue - audioSource.time > -1) //manager[i].SpawnCue <= audioSource.time
            {
                GameObject obj = Instantiate(ballPrefab, spawners[manager[i].SpawnIndex].position, Quaternion.identity);

                obj.transform.localScale = new Vector3(manager[i].InitialScale, manager[i].InitialScale, manager[i].InitialScale);

                if (manager[i].Movement.CanMove)
                {
                    obj.GetComponent<Ball>().canMove = true;
                    obj.GetComponent<Ball>().ballSpeed = manager[i].Movement.BallSpeed;
                    obj.GetComponent<Ball>().direction = manager[i].Movement.Direction;
                }

                if (manager[i].Scaling.CanGrow)
                {
                    obj.GetComponent<Ball>().canGrow = true;
                    obj.GetComponent<Ball>().scaleSpeed = manager[i].Scaling.GrowSpeed;
                }

                if (manager[i].Colouring.ColourChange)
                {
                    obj.GetComponent<Ball>().canColourChange = true;
                    obj.GetComponent<Ball>().colour = manager[i].Colouring.Colour;
                }

                obj.GetComponent<Ball>().pillarSpeed = manager[i].PillarSpeed;

                Destroy(obj, manager[i].DeathTime);

                manager.RemoveAt(i);
                i--;

            }
        }

    }
}
