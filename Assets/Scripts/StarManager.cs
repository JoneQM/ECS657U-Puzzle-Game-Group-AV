using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq; 

public class StarManager : MonoBehaviour
{
    public TextMeshProUGUI starCounterText;
    private int totalStars;
    private int collectedStars = 0;

    private void Start()
    {
        // Find all active and inactive stars in the scene including those that are not part of the scene (like prefabs)
        totalStars = Resources.FindObjectsOfTypeAll<Star>().Where(star => star.gameObject.scene.buildIndex != -1).Count();
        UpdateStarCounterUI();
    }

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
        collectedStars++;
        UpdateStarCounterUI();
        CheckAllStarsCollected();
    }

    private void UpdateStarCounterUI()
    {
        // Update the text UI with the current star count
        starCounterText.text = " " + collectedStars + "/" + totalStars;
    }

    private void CheckAllStarsCollected()
    {
        // Check if all stars are collected
        if (collectedStars >= totalStars)
        {
            // All stars collected - proceed to load the next map or level
            Debug.Log("All stars collected! Proceed to the next level.");

            // Determine the current scene's name
            string currentSceneName = SceneManager.GetActiveScene().name;

            // Check if the current scene is the "Tutorial" scene
            if (currentSceneName == "Tutorial")
            {
                // Load the "Main Menu" scene
                SceneManager.LoadScene("MainMenu");
            }
            else if (currentSceneName == "Level1")
            {
                // Load the "Main Menu" scene
                SceneManager.LoadScene("Level2");
            }
            else 
            {
                // Load the next scene
                SceneManager.LoadScene("Level3");
            }
        }
    }
}
