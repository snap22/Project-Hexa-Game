using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    void Awake()
    {
        Instance = this;
    }

    [System.Serializable]
    public class AudioUnit
    {
        public string name;
        public AudioClip sound;
    }
    public AudioUnit[] sounds;

    public AudioSource soundSource;
    public AudioSource musicSource;
    public AudioSource toolSource;

 

    public void PlaySoundEffect(string audioName)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (sounds[i].name == audioName)
                PlaySoundEffect(i);
        }

    }

    public void PlaySoundEffect(int index)
    {
        if (index < 0 || index >= sounds.Length)
            return;
        soundSource.clip = sounds[index].sound;
        soundSource.Play();
    }

    public void PlayToolSoundEffect(int index)
    {
        if (index < 0 || index >= sounds.Length)
            return;
        toolSource.clip = sounds[index].sound;
        toolSource.Play();
    }
}
