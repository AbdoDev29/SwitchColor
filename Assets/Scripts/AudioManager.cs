using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sound;
    void Start()
    {
        foreach(Sound s in sound)
        {
            s.audioSource=gameObject.AddComponent<AudioSource>();
            s.audioSource.clip = s.audioClip;
            s.audioSource.loop = s.loop;
            s.audioSource.volume = s.volume;
            s.audioSource.pitch = s.pitch;
        }

     
    }

    public void PlaySound(string name)
    {
        foreach (Sound s in sound)
        {
            if (s.name == name)
            {
                s.audioSource.Play();
            }
        }
    }
}
