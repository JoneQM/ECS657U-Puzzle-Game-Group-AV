// using UnityEngine;

// public class BackgroundMusic : MonoBehaviour
// {
//     public AudioSource backgroundMusic;

//     void Start()
//     {
//         // Ensures only one instance of BackgroundMusic exists
//         BackgroundMusic[] existingInstances = Object.FindObjectsOfType<BackgroundMusic>(includeInactive: true);

//         if (existingInstances.Length > 1)
//         {
//             Destroy(gameObject); // Destroys duplicate instances
//         }
//         else
//         {
//             DontDestroyOnLoad(gameObject); // Makes sure this GameObject persists across scenes

//             // Plays the background music when the game starts
//             if (backgroundMusic != null)
//             {
//                 backgroundMusic.playOnAwake = true; // Ensure it plays on start
//                 backgroundMusic.loop = true; // Enables looping
//                 backgroundMusic.Play();
//             }
//         }
//     }

//     void Update()
//     {

//     }
// }
