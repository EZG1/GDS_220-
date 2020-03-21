using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_TransformMod : MonoBehaviour
{
    public int _band;
    public float _startScale, _scaleMultiplier;
    private bool _useBuffer = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_useBuffer)
        {
            transform.position = new Vector3(transform.position.x, (A_AudioVisualization._audioBandBuffer[_band] * _scaleMultiplier) + _startScale, transform.position.z);
        }
        if (!_useBuffer)
        {
            transform.position = new Vector3(transform.position.x, (A_AudioVisualization._audioBandBuffer[_band] * _scaleMultiplier) + _startScale, transform.position.z);
        }
    }
}