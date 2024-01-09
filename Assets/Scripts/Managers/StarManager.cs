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
        // Find all active and inactive stars in the scene, including those that are not part of the scene (like prefabs)
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
        
        starCounterText.text = " " + collectedStars + "/" + totalStars;
    }

    private void CheckAllStarsCollected()
    {
        // Check if all stars are collected
        if (collectedStars >= totalStars)
        {
            
            Debug.Log("All stars collected! Proceed to the next level.");

            
            string currentSceneName = SceneManager.GetActiveScene().name;

            
            int currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

            
            int nextSceneBuildIndex = currentSceneBuildIndex + 1;

            if (currentSceneName == "Tutorial")
            {
                // Load the "Main Menu" scene if the current scene is "Tutorial"
                SceneManager.LoadScene("MainMenu");
            }
            else if (nextSceneBuildIndex < SceneManager.sceneCountInBuildSettings)
            {
                // Load the next scene by build index if there are more levels
                SceneManager.LoadScene(nextSceneBuildIndex);
            }
            else
            {
                // Load the Main Menu scene if there are no more levels
                SceneManager.LoadScene("MainMenu");
            }

            UnlockNewLevel();
        }
    }

    void UnlockNewLevel()
    {
        // Get the build index of the current level
        int currentLevelBuildIndex = SceneManager.GetActiveScene().buildIndex;

        // The "Unlocked Level" key should only be updated if the current level is not the tutorial.
        // Assuming that tutorial has a build index of 1 and is not meant to unlock further levels.
        if (currentLevelBuildIndex != 1)
        {
            // Get the highest level unlocked so far.
            int highestLevelUnlocked = PlayerPrefs.GetInt("Unlocked Level", 1);

            // Unlock the next level only if the current level's build index is greater than the highest level unlocked so far.
            if (currentLevelBuildIndex > highestLevelUnlocked)
            {
                PlayerPrefs.SetInt("Unlocked Level", currentLevelBuildIndex);
                PlayerPrefs.Save();
            }
        }
    }
}

