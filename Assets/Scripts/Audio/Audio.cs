using System.Collections;
using System.Collections.Generic;
using Slothsoft.UnityExtensions;
using UnityEngine;

public class Audio : MonoBehaviour {
    public static Audio instance;

    [SerializeField, Expandable]
    AudioSource sourcePrefab = default;
    ISet<(AudioSource, AudioSource)> sources = new HashSet<(AudioSource, AudioSource)>();

    [SerializeField]
    AudioInfo[] availableBackgroundMusic = new AudioInfo[0];
    public bool playsForward {
        get => playsForwardCache;
        set {
            if (playsForwardCache != value) {
                playsForwardCache = value;
                foreach (var (forward, backward) in sources) {
                    if (value) {
                        forward.time = forward.clip.length - backward.time;
                        backward.Stop();
                        forward.Play();
                    } else {
                        backward.time = backward.clip.length - forward.time;
                        forward.Stop();
                        backward.Play();
                    }
                }
            }
        }
    }
    bool playsForwardCache;

    void OnEnable() {
        instance = this;
    }

    void Start() {
        if (availableBackgroundMusic.Length > 0) {
            Play(availableBackgroundMusic.RandomElement());
        }
    }

    public void Play(AudioInfo audio) {
        var forward = Instantiate(sourcePrefab, transform);
        forward.loop = audio.loop;
        forward.clip = audio.clip;
        forward.outputAudioMixerGroup = audio.mixer;
        forward.pitch = audio.pitch;
        forward.time = audio.timeOffset;

        var backward = Instantiate(sourcePrefab, transform);
        backward.loop = audio.loop;
        backward.clip = audio.clipReversed;
        backward.outputAudioMixerGroup = audio.mixer;
        backward.pitch = Rewind.instance.rewindSpeed * audio.pitch;
        backward.time = 1 - audio.timeOffset;
        
        if (playsForward) {
            forward.Play();
        } else {
            backward.Play();
        }

        sources.Add((forward, backward));

        if (!audio.loop) {
            // TODO: make this rewind-compatible
            StartCoroutine(CreateDestructionRoutine(forward));
        }
    }

    IEnumerator CreateDestructionRoutine(AudioSource source) {
        yield return new WaitForSeconds(source.clip.length);
        Destroy(source.gameObject);
    }
}