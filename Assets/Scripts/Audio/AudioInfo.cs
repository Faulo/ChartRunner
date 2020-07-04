using System;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public class AudioInfo {
    public AudioClip clip;
    public AudioClip clipReversed;
    public bool loop;
    public AudioMixerGroup mixer;
    public float pitch;
    public float timeOffset;
}