using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : MonoBehaviour
{
    public float targetChromaticAberration = 0;
    public float targetLensDisortion = 0;

    [SerializeField] Volume volume;
    LensDistortion lensDistortion;
    ChromaticAberration chromaticAberration;


    public static PostProcessingManager instance;

    void Awake() {
        instance = this;
        volume = gameObject.GetComponent<Volume>();
        volume.profile.TryGet(out chromaticAberration);
        volume.profile.TryGet(out lensDistortion);
    }

    private void Update() {
        lensDistortion.intensity.value = Mathf.Lerp(lensDistortion.intensity.value, targetLensDisortion, Time.deltaTime);
        chromaticAberration.intensity.value = Mathf.Lerp(chromaticAberration.intensity.value, targetChromaticAberration, Time.deltaTime);
    }

    public void ChangeLensDisortion(float newLensDisortion) {
        targetLensDisortion = newLensDisortion;
    }

    public void ChangeChromaticAberration(float newChromaticAberration) {
        targetChromaticAberration = newChromaticAberration;
    }
}
