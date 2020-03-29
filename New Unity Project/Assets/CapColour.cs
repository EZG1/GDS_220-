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
        

    }
    void Update()
    {

        Color GlowColor = new Color(0.1f, 0.5f, 0.8f);
        PillarGlow.SetColor("Color_78BD9413", GlowColor);
        
        
        Color GlowIntensity = new Color(0.3f, 0.3f, 0.3f);
        PillarGlow.SetColor("Color_848602D4", GlowIntensity);
        
        
        
        //Glow intensity is a greyscale
        //This means when changing the color all values have to be the same, IE,
        //public Color(float r, float g, float b);
    }

}
