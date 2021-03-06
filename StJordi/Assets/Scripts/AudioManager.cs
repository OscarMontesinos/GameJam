using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] listSounds;

    string botonControlado;
    [Range(0f, 1f)]
    public float volume;
    public bool function = false;
    public bool mute = false;
    public string botonFunction;
    public bool loop;
    private void Awake()
    {
        if (AudioManager.Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        } 
        else
        {
            Destroy(this);
        }



        foreach (Sound sound in listSounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.audioClip;

            sound.audioSource.volume = sound.volume * volume;
            sound.audioSource.playOnAwake = sound.playOnAwake;
        }
    }

    public void PlaySong(string name)
    {
        foreach (Sound sound in listSounds)
        {
            if (sound.name == name && !function && !mute && !loop)
            {
                sound.audioSource.Play();
            }
        }
    }


}
