﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Statistics : MonoBehaviour {

    public static Statistics instance;

    [Multiline(20)]
    public string statusText;

    //IDictionary<IntStatistic, int> intStatistics = new Dictionary<IntStatistic, int>();
    IDictionary<FloatStatistic, float> floatStatistics = new Dictionary<FloatStatistic, float>();
    IDictionary<DictionaryStatistic, IDictionary<string, float>> dictionaryStatistics = new Dictionary<DictionaryStatistic, IDictionary<string, float>>();
    IDictionary<Vector2Statistic, IList<Vector2>> vector2Statistics = new Dictionary<Vector2Statistic, IList<Vector2>>();

    void Awake() {
        instance = this;
        /*
        foreach (IntStatistic key in Enum.GetValues(typeof(IntStatistic))) {
            intStatistics[key] = 0;
        }
        //*/
        foreach (FloatStatistic key in Enum.GetValues(typeof(FloatStatistic))) {
            floatStatistics[key] = 0;
        }
        foreach (DictionaryStatistic key in Enum.GetValues(typeof(DictionaryStatistic))) {
            dictionaryStatistics[key] = new Dictionary<string, float>();
        }
        foreach (Vector2Statistic key in Enum.GetValues(typeof(Vector2Statistic))) {
            vector2Statistics[key] = new List<Vector2>();
        }
    }

    void Update() {
        var builder = new StringBuilder();

        /*
        builder.AppendLine(nameof(intStatistics));
        foreach (var pair in intStatistics) {
            builder.AppendLine($"{pair.Key}: {pair.Value}");
        }
        builder.AppendLine();
        //*/

        builder.AppendLine(nameof(floatStatistics));
        foreach (var pair in floatStatistics) {
            builder.AppendLine($"{pair.Key}: {pair.Value}");
        }
        builder.AppendLine();

        builder.AppendLine(nameof(dictionaryStatistics));
        foreach (var pair in dictionaryStatistics) {
            builder.AppendLine($"{pair.Key}: {pair.Value}");
        }
        builder.AppendLine();

        builder.AppendLine(nameof(vector2Statistics));
        foreach (var pair in vector2Statistics) {
            builder.AppendLine($"{pair.Key}: {string.Join(", ", pair.Value)}");
        }
        builder.AppendLine();

        statusText = builder.ToString();
    }

    /*
    //IntPair are singular integer values
    public void Add(IntStatistic id, int value) {
        intStatistics[id] += value;
    }
    public void Remove(IntStatistic id, int value) {
        intStatistics[id] -= value;
    }
    public int Get(IntStatistic id) {
        return intStatistics[id];
    }
    //*/

    //FloatPair are singular floating-point values
    public void Add(FloatStatistic id, float value) {
        floatStatistics[id] += value;
    }
    public void Remove(FloatStatistic id, float value) {
        floatStatistics[id] -= value;
    }
    public float Get(FloatStatistic id) {
        return floatStatistics[id];
    }

    //DictionaryPairs are lists of key-value pairs
    public void Add(DictionaryStatistic id, string name, float value) {
        if (dictionaryStatistics[id].ContainsKey(name)) {
            dictionaryStatistics[id][name] += value;
        } else {
            dictionaryStatistics[id][name] = value;
        }
    }
    public void Remove(DictionaryStatistic id, string name, float value) {
        if (dictionaryStatistics[id].ContainsKey(name)) {
            dictionaryStatistics[id][name] -= value;
        } else {
            dictionaryStatistics[id][name] = -value;
        }
    }
    public IEnumerable<(string, float)> Get(DictionaryStatistic id) {
        foreach (var pair in dictionaryStatistics[id]) {
            yield return (pair.Key, pair.Value);
        }
    }

    //Vector2Pairs are lists of Vector2 values
    public void Add(Vector2Statistic id, Vector2 value) {
        vector2Statistics[id].Add(value);
    }
    public void Add(Vector2Statistic id, float value) {
        vector2Statistics[id].Add(new Vector2(floatStatistics[FloatStatistic.TimePassed], value));
    }
    public void Remove(Vector2Statistic id, Vector2 value) {
        for (int i = vector2Statistics[id].Count - 1; i >= 0; i--) {
            if (vector2Statistics[id][i] == value) {
                vector2Statistics[id].RemoveAt(i);
                break;
            }
        }
    }
    public IEnumerable<Vector2> Get(Vector2Statistic key) {
        return vector2Statistics[key];
    }
}
