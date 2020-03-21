using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_AudioVisualization : MonoBehaviour
{
    AudioSource _audioSource;
    public static float[] _samplesLeft = new float[512];     
    public static float[] _samplesRight = new float[512]; 
    float[] _freqBand = new float[8];
    float[] _bandBuffer = new float[8];
    float[] _bufferDecrease = new float[8];

    float[] _freqBandHighest = new float[8];
    public static float[] _audioBand = new float[8];
    public static float[] _audioBandBuffer = new float[8];

    public static float _Amplitude, _amplitudeBuffer;
    float _amplitudeHighest;
    float _audioProfile = 5;

    public enum _channel {Stereo, Left, Right};
    public _channel channel = new _channel();

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        AudioProfile(_audioProfile);
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        GetSpectrumAudioSource();
        MakeFreuquencyBands();
        BandBuffer();
        CreateAudioBands();
        GetAmplitude();
    }
    void AudioProfile(float audioProfile)
    {
        for (int i = 0; i < 8; i++)
        {
            _freqBandHighest[i] = audioProfile;
        }
    }

    void CreateAudioBands()
    {
        for (int i = 0; i < 8; i++)
        {
            if (_freqBand[i] > _freqBandHighest[i])
            {
                _freqBandHighest[i] = _freqBand[i];
            }
            _audioBand[i] = (_freqBand[i] / _freqBandHighest[i]);
            _audioBandBuffer[i] = (_bandBuffer[i] / _freqBandHighest[i]);
        }
    }
    void GetAmplitude()
    {
        float _currentAmplitude = 0;
        float _currentAmplitudeBuffer = 0;
        for (int i = 0; i < 8; i++)
        {
            _currentAmplitude += _audioBand[i];
            _currentAmplitudeBuffer += _audioBandBuffer[i];
        }
        if (_currentAmplitude > _amplitudeHighest)
        {
            _amplitudeHighest = _currentAmplitude;
        }
        _Amplitude = _currentAmplitude / _amplitudeHighest;
        _amplitudeBuffer = _currentAmplitude / _amplitudeHighest;
    }
    void BandBuffer()
    {
        for (int g = 0; g < 8; ++g)
        {
            if (_freqBand[g] > _bandBuffer[g])
            {
                _bandBuffer[g] = _freqBand[g];
                _bufferDecrease[g] = 0.005f;
            }
            if (_freqBand[g] < _bandBuffer[g])
            {
                _bandBuffer[g] -= _bufferDecrease[g];
                _bufferDecrease[g] *= 1.2f;
            }

        }
    }
    void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(_samplesLeft, 0, FFTWindow.Blackman);  //Left Channel Spectrum Data
        _audioSource.GetSpectrumData(_samplesRight, 1, FFTWindow.Blackman); //Right Channel Spectrum Data

    }
    void MakeFreuquencyBands()
    {
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++)
            {
                if (channel == _channel.Stereo) //If Channel is set to Stereo the Left&Right Sample Data will be used. 
                {
                    average += _samplesLeft[count] + _samplesRight[count] * (count + 1);
                }
                if (channel == _channel.Left) //If Channel is set to Left only the Left Sample Data will be used. 
                {
                    average += _samplesLeft[count] * (count + 1);
                }
                if (channel == _channel.Right) //If Channel is set to Right only the Left Sample Data will be used. 
                {
                    average += _samplesRight[count] * (count + 1);
                }
                
                count++;
            }
            average /= count;
            _freqBand[i] = average * 10;
        }

    }
}