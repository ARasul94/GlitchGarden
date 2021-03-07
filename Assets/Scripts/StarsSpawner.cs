using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsSpawner : MonoBehaviour
{
    [SerializeField][Tooltip("Base stars to add")] private int baseStarsToAdd = 3;

    private StarDisplay _starDisplay;

    private void Awake()
    {
        _starDisplay = FindObjectOfType<StarDisplay>();
    }

    public void AddStar()
    {
        _starDisplay.AddStars(baseStarsToAdd - PlayerPrefsController.GetDifficulty());
    }

}
