using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
                // Check for the "P" key press to toggle pause
        if (Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;

        isPaused = true;
    }

    public void Resume()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        // Load the MainMenu scene
        SceneManager.LoadScene("MainMenu");
    }

}
