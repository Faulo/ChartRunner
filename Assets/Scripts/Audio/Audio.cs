using System.Collections;
using System.Collections.Generic;
using Slothsoft.UnityExtensions;
using UnityEngine;

public class Audio : MonoBehaviour {
    public static Audio instance;

    [SerializeField, Expandable]
    AudioSource sourcePrefab = default;
    ISet<AudioSource> sources = new HashSet<AudioSource>();

    [SerializeField]
    AudioInfo[] availableBackgroundMusic = new AudioInfo[0];
    public bool playsForward {
        get => playsForwardCache;
        set {
            if (playsForwardCache != value) {
                playsForwardCache = value;
                foreach (var source in sources) {
                    source.pitch = playsForwardPitch;
                }
            }
        }
    }
    bool playsForwardCache;
    int playsForwardPitch => playsForward ? 1 : -2;

    void OnEnable() {
        instance = this;
    }

    void Start() {
        if (availableBackgroundMusic.Length > 0) {
            Play(availableBackgroundMusic.RandomElement());
        }
    }

    public void Play(AudioInfo audio) {
        var source = Instantiate(sourcePrefab, transform);
        source.loop = audio.loop;
        source.clip = audio.clip;
        source.outputAudioMixerGroup = audio.mixer;
        source.pitch = audio.pitch;
        source.time = audio.timeOffset;
        source.Play();

        sources.Add(source);

        if (!audio.loop) {
            // TODO: make this rewind-compatible
            StartCoroutine(CreateDestructionRoutine(source));
        }
    }

    IEnumerator CreateDestructionRoutine(AudioSource source) {
        yield return new WaitForSeconds(source.clip.length);
        Destroy(source.gameObject);
    }
}