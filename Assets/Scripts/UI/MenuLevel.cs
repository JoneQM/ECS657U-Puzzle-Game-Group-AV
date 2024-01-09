using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuLevel : MonoBehaviour
{
    public Button[] buttons;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("Unlocked Level", 1);
        for (int i = unlockedLevel; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            if (i < buttons.Length)
            {
                buttons[i].interactable = true;
            }
        }
    }

    public void OpenLevel(int levelId)
    {
        string levelName = "Level" + (levelId - 1);
        SceneManager.LoadScene(levelName);
    }
}
