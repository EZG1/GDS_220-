using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

public class CapColour : MonoBehaviour
{
    public Material PillarGlow;
    UnityEngine.Color GlowColor;
    UnityEngine.Color GlowIntensity;
    UnityEngine.Color BaseColor;
    
    void Start()
    {
        StartCoroutine("PillarCoroutine");
        
        GlowColor = new UnityEngine.Color(0.1f, 0.5730338f, 1f);
        BaseColor = new UnityEngine.Color(0.0f, 0.2150229f, 0.6698113f);
        GlowIntensity = new UnityEngine.Color(0.8f, 0.8f, 0.8f);
        
        //Glow intensity is a greyscale
        //This means when changing the color all values have to be the same, IE,
        //public Color(float r, float g, float b);
    }
    void Update()
    {
        PillarGlow.SetColor("Color_78BD9413", GlowColor);
        PillarGlow.SetColor("Color_848602D4", GlowIntensity);
        PillarGlow.SetColor("Color_736EF487", BaseColor);
    }
    
    IEnumerator PillarCoroutine()
        {
            
        yield return new WaitForSeconds(5);
        Debug.Log("Started Coroutine at timestape :" + Time.time);
        GlowIntensity = new UnityEngine.Color(1f, 1f, 1f);
        GlowColor = new UnityEngine.Color(0.4f, 0.213321f, 0.5643f);

        }
}
