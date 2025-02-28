using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] public GameObject gameOverScene;
    public void Restart()
    {
        Invoke("RestartDelay",1f);
        gameOverScene.SetActive(false);
        CharacterControl.resume = false;
        HealthSystem.health = 3;
        Score.carrot = 0;
        Score.score = 0;
        Enemy.killcounter = 0;
        Death.deathcounter = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene(1);

        // Get last level the player was on
        int lastLevel = PlayerPrefs.GetInt("LastLevel", SceneManager.GetActiveScene().buildIndex);

        // Restart the last level instead of always Level 1
        SceneManager.LoadScene(lastLevel);
    }
    void RestartDelay()
    {
        //
    }
}
