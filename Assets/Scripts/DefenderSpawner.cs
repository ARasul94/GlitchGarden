﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private Defender _defender;

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        _defender = defenderToSelect;
    }

    private void OnMouseDown()
    {
        SpawnDefender(GetClickedPosition());
    }

    private Vector2 GetClickedPosition()
    {
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return SnapToGrid(mouseWorldPos);
    }

    private Vector2 SnapToGrid(Vector2 oldPos)
    {
        var newX = Mathf.RoundToInt(oldPos.x);
        var newY = Mathf.RoundToInt(oldPos.y);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 position)
    {
        if (!_defender)
            return;
        
        Instantiate(_defender, position, Quaternion.identity);
    }
}