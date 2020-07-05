using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PostProcessing", menuName = "ScriptableObjects/PostProcessing", order = 1)]
public class PostProcessing : ScriptableObject {
    public float newChromaticAberation = 0;
    public float newLensDisortion = 0;
    public float motionBlur = 0;
    public float bloom = 0;

    public void ChromaticAberration() {
        PostProcessingManager.instance.ChangeChromaticAberration(newChromaticAberation);
    }

    public void LensDisortion() {
        PostProcessingManager.instance.ChangeLensDisortion(newLensDisortion);
    }

    public void MotionBlur() {
        PostProcessingManager.instance.ChangeMotionBlur(motionBlur);
    }

    public void Bloom() {
        PostProcessingManager.instance.ChangeBloom(bloom);

    }
}
