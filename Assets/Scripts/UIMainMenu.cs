using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] Button newGame;

    // Start is called before the first frame update
    void Start()
    {
        newGame.onClick.AddListener(StartNewGame);
    }

    private void StartNewGame()
    {
        ScenesManager.Instance.LoadNewGame();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}


// public class MainMenu : MonoBehaviour
// {
//     public void PlayGame()
//     {
//         SceneManager.LoadSceneAsync(1);
//     }

// }