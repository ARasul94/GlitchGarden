using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public static class PlayerPrefsController
{
    public static readonly UnityEvent<float> OnVolumeChanged = new Slider.SliderEvent();
    public static readonly UnityEvent<float> OnDifficultyChanged = new Slider.SliderEvent();
    private const string VOLUME_KEY = "volume";
    private const string DIFFICULTY_KEY = "difficulty";

    private const float MIN_VOLUME = 0;
    private const float MAX_VOLUME = 1;
    
    private const float MIN_DIFFICULTY = 0;
    private const float MAX_DIFFICULTY = 2;

    public static void SetVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(VOLUME_KEY, volume);
            OnVolumeChanged.Invoke(volume);
        }
        else
        {
            Debug.LogError($"Not allowed volume value. Try between {MIN_VOLUME} and {MAX_VOLUME}");
        }
    }

    public static float GetVolume()
    {
        return PlayerPrefs.GetFloat(VOLUME_KEY);
    }
    
    public static void SetDifficulty(int difficulty)
    {
        if (difficulty >= MIN_DIFFICULTY && difficulty <= MAX_DIFFICULTY)
        {

            PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
            OnDifficultyChanged.Invoke(difficulty);
        }
        else
        {
            Debug.LogError($"Not allowed difficulty value. Try between {MIN_DIFFICULTY} and {MAX_DIFFICULTY}");
        }
    }

    public static int GetDifficulty()
    {
        return PlayerPrefs.GetInt(DIFFICULTY_KEY);
    }
}
