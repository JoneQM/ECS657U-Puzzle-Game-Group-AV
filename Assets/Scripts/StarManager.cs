using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
            // All stars collected - proceed to load the next scene
            int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;

            if (nextSceneIndex < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                // No more scenes to load (end of the game, for example)
                Debug.Log("No more scenes to load.");
            }
        }
    }

}
