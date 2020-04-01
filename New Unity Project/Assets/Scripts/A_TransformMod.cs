using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_TransformMod : MonoBehaviour
{
    public int _band;
    public float _startScale, _scaleMultiplier;
    private bool _useBuffer = true;
    float startPos;

    float fallSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (_useBuffer && transform.position.y < startPos + (A_AudioVisualization._audioBandBuffer[_band] * _scaleMultiplier) + _startScale)
        {
            transform.position = new Vector3(transform.position.x, startPos + (A_AudioVisualization._audioBandBuffer[_band] * _scaleMultiplier) + _startScale, transform.position.z);
            fallSpeed = 0f;
        }
        if (transform.position.y > startPos)
        {
            fallSpeed += 0.0005f;
            transform.position = new Vector3(transform.position.x, transform.position.y - fallSpeed, transform.position.z);
            //transform.position = new Vector3(transform.position.x, startPos + (A_AudioVisualization._audioBandBuffer[_band] * _scaleMultiplier) + _startScale, transform.position.z);
        }
    }
}

/*
    {
        if (_useBuffer)
        {
            transform.position = new Vector3(transform.position.x, startPos + (A_AudioVisualization._audioBandBuffer[_band] * _scaleMultiplier) + _startScale, transform.position.z);
        }
        if (!_useBuffer)
        {
            transform.position = new Vector3(transform.position.x, startPos + (A_AudioVisualization._audioBandBuffer[_band] * _scaleMultiplier) + _startScale, transform.position.z);
        }
    }
 */
