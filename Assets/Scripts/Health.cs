// using UnityEngine;
// using UnityEngine.UI;
// NOT IN GAME

// public class Health : MonoBehaviour
// {
//     public int maxHealth = 100;
//     public int currentHealth;
//     public Slider healthSlider;

    

    

//     void Start()
//     {
//         currentHealth = maxHealth;
//         UpdateHealthUI();
//     }

//     public void TakeDamage(int damage)
//     {
//         currentHealth -= damage;
//         currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
//         UpdateHealthUI();

//         if (currentHealth <= 0)
//         {
//             Die();
//         }
//     }

//     private void UpdateHealthUI()
//     {
//         if (healthSlider)
//         {
//             healthSlider.value = (float)currentHealth / maxHealth;
//         }
//     }

//     private void Die()
//     {
//         // Handle the player's death here
//         Debug.Log(transform.name + " has died.");
//     }
// }
