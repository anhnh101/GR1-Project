using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource bgMusicSource;
    public AudioMixer audioMixer;
    public AudioClip bgMusicClip;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        bgMusicSource.clip = bgMusicClip;
        bgMusicSource.Play();
    }
}
