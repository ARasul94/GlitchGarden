using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Slider))]
public class GameTimer : MonoBehaviour
{
    [Tooltip("Level time is seconds")]
    [SerializeField] private int levelTime = 10;
    
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        var time = Time.timeSinceLevelLoad / levelTime;

        _slider.value = time;
    }
}
