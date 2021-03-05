using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LivesDisplay : MonoBehaviour
{
    [SerializeField] private int baseLives = 5;
    
    public readonly UnityEvent OnLivesEnded = new UnityEvent();

    private int lives;
    private Text _livesText;
    private int _damage = 1;
    private SceneLoader _sceneLoader;

    private void Awake()
    {
        _livesText = GetComponent<Text>();
        _sceneLoader = FindObjectOfType<SceneLoader>();
        if (_sceneLoader == null)
            throw new Exception($"No SceneLoader Object on {SceneManager.GetActiveScene().name} scene");
    }

    private void Start()
    {
        lives = baseLives - PlayerPrefsController.GetDifficulty();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        _livesText.text = lives.ToString();
    }

    public void AddLife()
    {
        lives += 1;
        UpdateDisplay();
    }

    public void LoseLife()
    {
        if (lives <= 0)
        {
            OnLivesEnded.Invoke();
            return;
        }
        lives -= _damage;
        UpdateDisplay();
    }
}