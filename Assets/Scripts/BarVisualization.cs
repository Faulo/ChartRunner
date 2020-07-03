using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarVisualization : MonoBehaviour
{
    public Bar bar = default;


    void Start()
    {
        
    }

    void Update() {
        // magic number 0.256 pro 0.1 Verschiebung nach oben
        this.transform.localScale = new Vector3(0.1f, bar.value / 10f, 0.1f);

        float offset = 0.256f;
        this.transform.position = new Vector3(this.transform.position.x, bar.value * offset, 0);
    }
}
