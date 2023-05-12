using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class BombCounter : MonoBehaviour
{
    public static BombCounter bombCounter;

    private void Start()
    {
        bombCounter = this;
    }

    public void UpdateWith(int count)
    {
        GetComponent<TextMeshProUGUI>().text = count.ToString();
    }
}
