using System;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public class AudioInfo {
    public AudioClip clip;
    public bool loop;
    public AudioMixerGroup mixer;
    public float pitch;
    public float timeOffset;
}