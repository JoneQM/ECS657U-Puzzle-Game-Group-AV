using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    // [SerializeField] Button newGame;
    [SerializeField] Button tutorialButton;
    void Start()
    {
        // newGame.onClick.AddListener(StartNewGame);
        tutorialButton.onClick.AddListener(StartTutorial);
    }

    private void StartNewGame()
    {
        ScenesManager.Instance.LoadNewGame();
    }

    private void StartTutorial()
    {
        ScenesManager.Instance.LoadScene(ScenesManager.Scene.Tutorial);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
