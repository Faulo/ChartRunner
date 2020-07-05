using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GraphHeader : MonoBehaviour
{
    public SingleBar singleBar = default;
    public Vector3 offset = Vector3.zero;

    public void Start() {
        ApplyHeader(singleBar.statistic.Translate());
    }

    public void ApplyHeader(string newHeader) {
        this.GetComponent<TextMeshProUGUI>().text = newHeader;
    }

    private void Update() {
        this.transform.position = offset + singleBar.gameObject.transform.position;
    }
}
