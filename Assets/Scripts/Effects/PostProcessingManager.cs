using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : MonoBehaviour {
    public float targetChromaticAberration = 0;
    public float targetLensDisortion = 0;
    public float targetMotionBlur = 0;
    public float targetBloom = 0;

    [SerializeField] Volume volume = default;
    LensDistortion lensDistortion = default;
    ChromaticAberration chromaticAberration = default;
    MotionBlur motionBlur = default;
    Bloom bloom = default;


    public static PostProcessingManager instance;

    void Awake() {
        instance = this;
        volume = gameObject.GetComponent<Volume>();
        volume.profile.TryGet(out chromaticAberration);
        volume.profile.TryGet(out lensDistortion);
        volume.profile.TryGet(out motionBlur);
        volume.profile.TryGet(out bloom);
    }

    void Update() {
        lensDistortion.intensity.value = Mathf.Lerp(lensDistortion.intensity.value, targetLensDisortion, Time.deltaTime);
        chromaticAberration.intensity.value = Mathf.Lerp(chromaticAberration.intensity.value, targetChromaticAberration, Time.deltaTime);
        motionBlur.intensity.value = Mathf.Lerp(motionBlur.intensity.value, targetMotionBlur, Time.deltaTime);
        bloom.intensity.value = Mathf.Lerp(bloom.intensity.value, targetBloom, Time.deltaTime);
    }

    public void ChangeLensDisortion(float newLensDisortion) {
        targetLensDisortion = newLensDisortion;
    }

    public void ChangeChromaticAberration(float newChromaticAberration) {
        targetChromaticAberration = newChromaticAberration;
    }

    public void ChangeMotionBlur(float newMotionBlur) {
        targetMotionBlur = newMotionBlur;
    }

    public void ChangeBloom(float newBloom) {
        targetBloom = newBloom;
    }
}
