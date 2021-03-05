using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayerPrefsController.OnVolumeChanged.AddListener(SetVolume);
        SetVolume(PlayerPrefsController.GetVolume());
    }

    private void SetVolume(float volume)
    {
        _audioSource.volume = volume;
    }
}
