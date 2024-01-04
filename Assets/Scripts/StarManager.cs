using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Include the TextMeshPro namespace

public class StarManager : MonoBehaviour
{
    public TextMeshProUGUI starCounterText; // Assign this in the inspector
    private int starCount = 0;

    private void OnEnable()
    {
        Star.OnStarCollected += HandleStarCollected;
    }

    private void OnDisable()
    {
        Star.OnStarCollected -= HandleStarCollected;
    }

    private void HandleStarCollected()
    {
        starCount++;
        UpdateStarCounterUI();
    }

    private void UpdateStarCounterUI()
    {
        // Update the text UI with the current star count
        starCounterText.text = " " + starCount;
    }
}

