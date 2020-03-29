using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

public class CapColour : MonoBehaviour
{
    public Material PillarGlow;
    Color GlowColor;
    Color GlowIntensity;
    void start()
    {
        StartCoroutine("PillarCoroutine");
        
        Color GlowColor = new Color(0.1f, 0.5730338f, 1f);
        Color BaseColor = new Color(0.0f, 0.2150229f, 0.6698113f);
        Color GlowIntensity = new Color(0.8f, 0.8f, 0.8f);
        
        PillarGlow.SetColor("Color_78BD9413", GlowColor);
        PillarGlow.SetColor("Color_848602D4", GlowIntensity);
        PillarGlow.SetColor("Color_736EF487", BaseColor);
        
       
        
        
        
        
        //Glow intensity is a greyscale
        //This means when changing the color all values have to be the same, IE,
        //public Color(float r, float g, float b);
    }
    void Update()
    {
        
    }
    
    IEnumerator PillarCoroutine()
        {
            Debug.Log("Started Coroutine at timestape :" + Time.time);
            yield return new WaitForSeconds(5);
            Color GlowIntensity = new Color(1f, 1f, 1f);
        }
}
