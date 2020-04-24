using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialVariants : MonoBehaviour
{
    public Color MainColor;
    public Color SecondaryColor;
    public int Saturation;



    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = Instantiate<Material>(GetComponent<Renderer>().material);
    }

    // Update is called once per frame
    private void Update()
    {
        GetComponent<Renderer>().material.SetColor("Color_78BD9413", MainColor);
        GetComponent<Renderer>().material.SetColor("Color_78BD9413", SecondaryColor);
    }
}
