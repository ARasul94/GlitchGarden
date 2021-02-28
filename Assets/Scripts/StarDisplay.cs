using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour
{
    [SerializeField] private int stars = 100;

    private Text _starText;


    private void Awake()
    {
        _starText = GetComponent<Text>();
    }

    private void Start()
    {
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        _starText.text = stars.ToString();
    }

    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public void SpendStar(int amount)
    {
        if (stars < amount) 
            return;
        stars -= amount;
        UpdateDisplay();
    }

    public bool HaveEnoughStarsToBuild(int amount)
    {
        return stars >= amount;
    }

}
