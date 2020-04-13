using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WaveAudioChange : MonoBehaviour
{
    private void Start()
    {
       StartCoroutine("StartFade");
    }

}
