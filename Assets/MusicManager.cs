using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public static UnityEvent SetDialogue { private set; get; }
    public static UnityEvent SetEndgame { private set; get; }
    public static UnityEvent SetNormal { private set; get; }

    public AudioSource audio;

    public TimeSavedAudioClip music;
    public TimeSavedAudioClip dialogueMusic;
    public TimeSavedAudioClip endgameMusic;

    static TimeSavedAudioClip current;
    public static TimeSavedAudioClip Current { get {
            return current;
    }}

    private void Awake()
    {
        SetDialogue = new UnityEvent();
        SetEndgame = new UnityEvent();
        SetNormal = new UnityEvent();

        audio = GetComponent<AudioSource>();

        SetDialogue.AddListener(() => {
            // dialogueMusic.time = 0;
            setClip(dialogueMusic);
        });
        SetEndgame.AddListener(() => setClip(endgameMusic));
        SetNormal.AddListener(() => setClip(music));

        current = music;
    }

    void setClip(TimeSavedAudioClip clip)
    {
        current.time = audio.time;
        audio.clip = clip.clip;
        audio.time = clip.time;
        if(!audio.isPlaying)
        {
            audio.Play();
        }
        current = clip;
    }

    [System.Serializable]
    public class TimeSavedAudioClip
    {
        public AudioClip clip;
        [HideInInspector]
        public float time;
    }
}
