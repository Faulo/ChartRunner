﻿using Slothsoft.UnityExtensions;
using UnityEngine;

public class PlayButton : MonoBehaviour {
    [SerializeField]
    float threshold = 5;
    [SerializeField, Expandable]
    SingleBar singleBar = default;
    bool starting = false;
    void OnValidate() {
        if (!singleBar) {
            singleBar = GetComponentInChildren<SingleBar>();
        }
    }
    void Start() {
        if (singleBar) {
            if (Statistics.instance.Get(singleBar.statistic) >= threshold) {
                StartGame();
            }
        }
    }

    void StartGame() {
        if (!starting) {
            starting = true;
            //LOAD NEXT SCENE
        }
    }
}
