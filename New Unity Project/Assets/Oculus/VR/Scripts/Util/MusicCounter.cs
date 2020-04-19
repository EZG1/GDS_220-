using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCounter : MonoBehaviour
{
    AudioSource audioSource;

    public delegate void MusicTrigger();
    public static event MusicTrigger Rain;
    public static event MusicTrigger End;

    bool rainTrigger;
    bool endTrigger;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(audioSource.time); //for testing purposes

        if (audioSource.time > 95 && !rainTrigger)
        {
            rainTrigger = true;
            Rain();
        }

        if (audioSource.time > 135 && !endTrigger)
        {
            endTrigger = true;
            End();
        }
    }
}
