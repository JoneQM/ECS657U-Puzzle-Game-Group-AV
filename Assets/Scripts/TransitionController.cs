using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{
    public Animator animator;
    public void FadeToLevel (int levelIndex)
    {
        animator.SetTrigger("Fade Out");
    }

    public void OnFadeFinish()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
