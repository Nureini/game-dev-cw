using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    // initially player starts with a health limit of 10
    public int initalPlayerHealth = 10;
    public int currentHealth;
    public TextMeshProUGUI healthText;

    void Start()
    {
        currentHealth = initalPlayerHealth;
    }

    public void UpdatePlayerHealth(int healthToLose)
    {
        // to update the players health every time the player takes some sort of damage from an enemy attack.
        currentHealth -= healthToLose;

        // Updates the healthText displayed on the GUI (TEXT MESH PRO)
        healthText.text = "Health: " + currentHealth;

        if (currentHealth <= 0)
        {
            // if the player dies display the game over screen and user has to start from the beginning again
            SceneManager.LoadScene("GameOver");
        }
    }


}
