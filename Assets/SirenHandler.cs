using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(AudioSource))]
public class SirenHandler : MonoBehaviour
{
    [SerializeField] RussiaManager russia;
    bool sirenEnabled = false;
    Image img;
    AudioSource audio;
    public List<Func<bool>> conditions = new List<Func<bool>>();

    void Start()
    {
        img = GetComponent<Image>();
        audio = GetComponent<AudioSource>();
        conditions.Add(() =>
        {
            if(GameManager.Singleton.bombCount - russia.bombs < 2 && russia.gameObject.activeSelf)
            {
                return true;
            }
            return false;
        });
        conditions.Add(() =>
        {
            return GameManager.Singleton.getYear() > 1961.6 && GameManager.Singleton.getYear() < 1962;
        });
    }

    // Update is called once per frame
    void Update()
    {
        if(sirenEnabled)
        {
            return;
        }
        foreach(var cond in conditions)
        {
            if(cond()) {
                UpdateSiren();
                return;
            }
        }
        ResetSiren();
    }

    void UpdateSiren()
    {
        SetSirenAlpha(Math.map(MathF.Sin(Time.realtimeSinceStartup), -1, 1, 0, 0.45f));
        if(!audio.isPlaying)
        {
            audio.Play();
        }
    }

    void ResetSiren()
    {
        Debug.Log("stopped");
        SetSirenAlpha(0);
        audio.Stop();
    }

    void SetSirenAlpha(float a)
    {
        var col = img.color;
        col.a = a;
        img.color = col;
    }

    public void EnableSiren()
    {
        sirenEnabled = true;
    }
}
