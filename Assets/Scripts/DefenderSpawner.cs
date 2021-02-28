using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    [SerializeField] private GameObject defender;

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
        Instantiate(defender, position, Quaternion.identity);
    }
}
