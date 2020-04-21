using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSound : MonoBehaviour
{
    AudioSource wave;
    void Start()
    {
       wave = GetComponent<AudioSource>();
    }

    void SoundPlay()
    {
        wave.Play();
    }
}
