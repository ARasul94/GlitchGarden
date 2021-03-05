using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField][Range(0, 1)] private float defaultVolume = 0.4f;
    [SerializeField][Range(0, 2)] private int defaultDifficulty = 0;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider difficultySlider;
    
    private void Start()
    {
        volumeSlider.onValueChanged.AddListener(SetVolume);
        difficultySlider.onValueChanged.AddListener(SetDifficulty);

        volumeSlider.value = PlayerPrefsController.GetVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    private void SetVolume(float volume)
    {
        PlayerPrefsController.SetVolume(volume);
    }

    private void SetDifficulty(float difficulty)
    {
        PlayerPrefsController.SetDifficulty((int)difficulty);
    }

    public void ResetOptions()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
