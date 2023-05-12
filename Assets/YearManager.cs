using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class YearManager : MonoBehaviour
{
    public static YearManager singleton;
    TextMeshProUGUI text;
    string prefix;

    private void Awake()
    {
        singleton = this;
        text = GetComponent<TextMeshProUGUI>();
        prefix = text.text;
    }

    public void UpdateWith(float year)
    {
        text.text = prefix + Mathf.FloorToInt(year);
    }
}
