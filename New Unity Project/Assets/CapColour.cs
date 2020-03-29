using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

public class CapColour : MonoBehaviour
{
    public Material PillarGlow;
    Color GlowColor;
    void start()
    {
       
    }
    void Update()
    {
       /// Color GlowColor = new Color(
       ///         Random.Range(0, 255),
        ///        Random.Range(0, 255),
        ///        Random.Range(0, 255));
       
        PillarGlow.SetColor("Color_78BD9413", GlowColor);
    }
    
}
