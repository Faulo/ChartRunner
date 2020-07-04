using System.Collections.Generic;
using Slothsoft.UnityExtensions;
using UnityEngine;

public class Audio : MonoBehaviour {
    public static Audio instance;

    [SerializeField, Expandable]
    AudioSource sourcePrefab = default;
    ISet<(AudioSource, AudioSource)> sources = new HashSet<(AudioSource, AudioSource)>();

    [SerializeField]
    GameObjectEvent onStart = default;

    bool playsForward {
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
        playsForward = true;
    }

    void Start() {
        Rewind.instance.onStartRewind += context => playsForward = false;
        Rewind.instance.onStopRewind += context => playsForward = true;

        onStart.Invoke(gameObject);
    }

    void Update() {
        // destroy finished audio sources
        foreach (var pair in sources) {
            if (!pair.Item1.isPlaying && !pair.Item2.isPlaying) {
                Destroy(pair.Item1.gameObject);
                Destroy(pair.Item2.gameObject);
                sources.Remove(pair);
                break;
            }
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

        if (audio.loop) {
            // can only play 1 looping audio at a time
            foreach (var pair in sources) {
                if (pair.Item1.loop) {
                    pair.Item1.Stop();
                    pair.Item2.Stop();
                }
            }
        }

        sources.Add((forward, backward));
    }
}