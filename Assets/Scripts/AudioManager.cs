using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    
    void Awake()
    {
       foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        } 
    }

    // Start is called before the first frame update
    void Start()
    {
        Play("BG"); //Plays BG music
    }

    public void Play(string soundName)
    {
        Sound s = Array.Find(sounds, sound => sound.name == soundName);

        if (s == null)
        {
            Debug.LogWarning("Error!! The sound\"" + soundName + "\"was not found. :(");
            return; //to avoid a NullReferenceException
        }
            

        s.source.Play();
    }
}
