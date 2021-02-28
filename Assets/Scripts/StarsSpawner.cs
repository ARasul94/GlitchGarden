using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsSpawner : MonoBehaviour
{
    [SerializeField] private int startToAdd = 2;

    private StarDisplay _starDisplay;

    private void Awake()
    {
        _starDisplay = FindObjectOfType<StarDisplay>();
    }

    public void AddStar()
    {
        _starDisplay.AddStars(startToAdd);
    }

}
