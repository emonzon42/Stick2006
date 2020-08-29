using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound //holds data for each sound which the audio manager uses to create audio sources
{
    public string name;
    public AudioClip clip;

    [Range(0f,1f)]
    public float volume;

    [Range(-3f,3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;

}
