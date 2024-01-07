using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{
    public Animator animator;

    // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         FadeToLevel(2);
    //     }
    // }

    public void FadeToLevel (int levelIndex)
    {
        animator.SetTrigger("Fade Out");
    }

    public void OnFadeFinish()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
