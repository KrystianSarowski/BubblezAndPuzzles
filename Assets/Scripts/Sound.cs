using UnityEngine.Audio;
using UnityEngine;
//@Author Krystian Sarowski
//Created using Breakeys wideo as a guide.

[System.Serializable]
public class Sound
{
    public string m_name;

    public AudioClip m_clip;

    public bool m_loop;

    [Range(0.0f, 1.0f)]
    public float m_volume;

    [Range(0.1f, 3.0f)]
    public float m_pitch;

    [HideInInspector]
    public AudioSource m_source;
}
