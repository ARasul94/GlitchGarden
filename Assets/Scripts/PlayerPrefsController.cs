using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefsController
{
    private const string VOLUME_KEY = "volume";
    private const string DIFFICULTY_KEY = "difficulty";

    private const float MIN_VOLUME = 0;
    private const float MAX_VOLUME = 1;

    public static void SetVolume(float volume)
    {
        if (volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(VOLUME_KEY, volume);
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
}
