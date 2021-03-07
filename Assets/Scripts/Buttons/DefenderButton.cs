using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] private Color32 defaultColor;
    [SerializeField] private Defender defenderPrefab;
    [SerializeField] private Text costText;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    
    
    public SpriteRenderer SpriteRenderer => spriteRenderer;
    
    
    private List<DefenderButton> _buttons;
    private DefenderSpawner _defenderSpawner;

    private void Awake()
    {
        _buttons = FindObjectsOfType<DefenderButton>().ToList();
        _defenderSpawner = FindObjectOfType<DefenderSpawner>();
    }

    private void Start()
    {
        spriteRenderer.color = defaultColor;
        costText.text = defenderPrefab.GetCost().ToString();
    }

    private void OnMouseDown()
    {
        foreach (var button in _buttons)
        {
            button.SpriteRenderer.color = defaultColor;
        }
        
        spriteRenderer.color = Color.white;
        _defenderSpawner.SetSelectedDefender(defenderPrefab);
    }
}
