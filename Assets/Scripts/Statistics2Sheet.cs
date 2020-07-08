using System.Collections.Generic;
using System.Text.RegularExpressions;
using Slothsoft.UnityExtensions;
using TMPro;
using UnityEngine;

public class Statistics2Sheet : MonoBehaviour {
    
    [SerializeField, Expandable]
    List<TextMeshProUGUI> values = default;

    Dictionary<string, string> namevaluepairs = new Dictionary<string, string>();

    Regex digit = new Regex(@"\d+");
    Regex upper = new Regex(@"^|\b[A-Z]");

    void Split() {
        int counterDigits = 0;

        string raw = Statistics.instance.statusText;
        string[] words = Regex.Split(raw, @"\s+"); 

        foreach (string word in words) {

                if (digit.Match(word).Success) { 
                    string d_s = Regex.Replace(word, @"[()\s]", "");
                    if (float.TryParse( d_s, out float d_f)) {
                        d_f = (float)System.Math.Round(d_f, 2);
                        values[counterDigits].text = d_f.ToString();
                    } else {
                        values[counterDigits].text = d_s;     
                    }
                    counterDigits += 1;
                }
        }
    }

    void Update() {
        Split();
    }
}

