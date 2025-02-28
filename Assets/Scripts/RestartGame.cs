using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] public GameObject gameOverScene;
    public void Restart()
    {
        Invoke("RestartDelay", 1f);
        gameOverScene.SetActive(false);
        CharacterControl.resume = false;
        HealthSystem.health = 3;
        Score.carrot = 0;
        Score.score = 0;
        Enemy.killcounter = 0;
        Death.deathcounter = 0;
        Time.timeScale = 1;
        //SceneManager.LoadScene(1);

        // Get last level the player was on
        int lastLevel = PlayerPrefs.GetInt("LastLevel", 1); // Default to Level 1 if nothing is saved

        // Restart the last level instead of always Level 1

        Debug.Log("Restarting at Level: " + lastLevel); // PRINT THE LEVEL TO DEBUG

        // Penalize the player: If restarting in Level 2, set health to 1
        if (lastLevel == 2)
        {
            HealthSystem.health = 1;
            Debug.Log("Penalty Applied: Player only has 1 life in Level 2.");
        }
        else
        {
            HealthSystem.health = 3; // Reset to full lives in Level 1
        }
        SceneManager.LoadScene(lastLevel);
    }
    void RestartDelay()
    {
        //
    }
}
