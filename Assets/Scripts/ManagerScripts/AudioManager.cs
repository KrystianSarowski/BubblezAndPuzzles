using UnityEngine.Audio;
using UnityEngine;
using System;
//@Author Krystian Sarowski
//Created using Breakeys wideo as a guide.

public class AudioManager : MonoBehaviour
{
    public Sound[] m_soundArray;

    public static AudioManager s_managerInstance;

    void Awake()
    {
        if(s_managerInstance == null)
        {
            s_managerInstance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        //Loop through sound array and create audio source for each sound.
        foreach(Sound s in m_soundArray)
        {
            s.m_source = gameObject.AddComponent<AudioSource>();

            s.m_source.clip = s.m_clip;
            s.m_source.loop = s.m_loop;
            s.m_source.pitch = s.m_pitch;
            s.m_source.volume = s.m_volume;
        }
    }

    void Start()
    {
        Play("BackgroundMusic");
    }

    //Play the sound that matches the entered name.
    public void Play(string t_soundName)
    {
        //Search the sounds array and find one that has the same name.
        Sound s = Array.Find(m_soundArray, sound => sound.m_name == t_soundName);

        if(null == s)
        {
            return;
        }

        s.m_source.Play();
    }
}
