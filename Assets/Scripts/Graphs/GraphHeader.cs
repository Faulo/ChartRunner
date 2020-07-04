using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GraphHeader : MonoBehaviour
{
    public void ApplyHeader(string newHeader) {
        this.GetComponent<TextMeshProUGUI>().text = newHeader;
    }
}
