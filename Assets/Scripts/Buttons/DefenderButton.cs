using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] private Color32 defaultColor;
    [SerializeField] private Defender defenderPrefab;
    
    
    public SpriteRenderer SpriteRenderer => _spriteRenderer;
    
    private SpriteRenderer _spriteRenderer;
    private List<DefenderButton> _buttons;
    private DefenderSpawner _defenderSpawner;

    private void Awake()
    {
        _buttons = FindObjectsOfType<DefenderButton>().ToList();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = defaultColor;
        _defenderSpawner = FindObjectOfType<DefenderSpawner>();
    }

    private void OnMouseDown()
    {
        foreach (var button in _buttons)
        {
            button.SpriteRenderer.color = defaultColor;
        }
        
        _spriteRenderer.color = Color.white;
        _defenderSpawner.SetSelectedDefender(defenderPrefab);
    }
}
