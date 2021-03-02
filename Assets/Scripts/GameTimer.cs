using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[RequireComponent(typeof(Slider))]
public class GameTimer : MonoBehaviour
{
    [Tooltip("Level time is seconds")]
    [SerializeField] private int levelTime = 10;

    private Slider _slider;
    private bool _levelTimeFinished;
    private LevelController _levelController;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _levelController = FindObjectOfType<LevelController>();
        if (_levelController == null)
            throw new Exception($"No LevelController Object on {SceneManager.GetActiveScene().name} scene");
    }

    private void Update()
    {
        if (_levelTimeFinished)
            return;
        
        var time = Time.timeSinceLevelLoad / levelTime;

        _slider.value = time;

        if (Time.timeSinceLevelLoad > levelTime)
        {
            _levelController.SetTimeAsFinished();
            _levelTimeFinished = true;
            Debug.Log("Time finished");
        }
    }
}
