using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioLerp : MonoBehaviour
{
    public AudioMixerSnapshot wave;
    public float audioFadeTime;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            wave.TransitionTo(audioFadeTime);
        }
    }
}
