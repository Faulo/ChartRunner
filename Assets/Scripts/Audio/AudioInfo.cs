using System;
using Slothsoft.UnityExtensions;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public class AudioInfo {
    [SerializeField, Expandable]
    public AudioClip clip = default;
    [SerializeField, Expandable]
    public AudioClip clipReversed = default;
    [SerializeField]
    public bool loop = false;
    [SerializeField, Expandable]
    public AudioMixerGroup mixer = default;
    [SerializeField, Range(0, 10)]
    public float pitch = 1;
}