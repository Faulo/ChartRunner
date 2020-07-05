using System.Collections.Generic;
using System.Text.RegularExpressions;
using Slothsoft.UnityExtensions;
using TMPro;
using UnityEngine;

public class Statistics2Sheet : MonoBehaviour {
    [SerializeField, Expandable]
    List<TextMeshProUGUI> names = default;
    [SerializeField, Expandable]
    List<TextMeshProUGUI> values = default;

    Dictionary<string, string> namevaluepairs = new Dictionary<string, string>();

    Regex digit = new Regex(@"\d+");
    Regex upper = new Regex(@"^|\b[A-Z]+[a-z]+\b");

    void Split() {
        string raw = Statistics.instance.statusText;
        
        string[] words = Regex.Split(raw, @"\s+");

        bool namevalueswitch = true;
        int counterUpper = 0;
        int counterDigits = 0;

        foreach (string word in words) {
            //LOGIC
            var matchDigit = digit.Match(word);
            var matchUpper = upper.Match(word);
            if (matchDigit.Success && namevalueswitch && counterDigits < values.Capacity ) {
                values[counterDigits].text = Regex.Replace(word, @"[\|\:()]", " ");
                counterDigits += 1;
                namevalueswitch = false;
                //Debug.Log(word);
            } else if (matchUpper.Success && counterUpper < names.Capacity) {
                names[counterUpper].text = Regex.Replace(word, @"[\:()]", " ");
                counterUpper += 1;
                namevalueswitch = true;
                //Debug.Log(word);
            }
            
        }
    }

    void Update() {
        Split();
    }
}

