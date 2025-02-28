using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] public AudioClip _audioclip;
    [SerializeField] public AudioSource _audiosource;
    [SerializeField] public GameObject ThinkingBallon;
    [SerializeField] public GameObject WinScene;

    private void Start()
    {
        // Save the level number immediately when the level starts
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("LastLevel", currentLevel);
        PlayerPrefs.Save();

        Debug.Log("Saved LastLevel as: " + currentLevel); // Debug log to confirm saving
    }
    public void SkipNextLevel()
    {
        Time.timeScale = 1;
        StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(0.5f);

        // Get the next level index
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;

        // Save the level the player is entering
        PlayerPrefs.SetInt("LastLevel", nextLevel);
        PlayerPrefs.Save();

        // Reset carrots and load next level
        Score.carrot = 0;
        SceneManager.LoadScene(nextLevel);
    }



    private void OnTriggerEnter2D(Collider2D other) 
    {
       // if (other.gameObject.CompareTag("Player") && Score.carrot>2)
        if (other.gameObject.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().buildIndex == 2)
            {
                _audiosource.PlayOneShot(_audioclip, 1);
                Invoke("Delay", 1f);
            }
            else
            {
                _audiosource.PlayOneShot(_audioclip, 1);
                StartCoroutine(LoadLevel());
            }
            
        }
        else
        {
            ThinkingBallon.SetActive(true);
        }    
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        ThinkingBallon.SetActive(false);
    }
    void Delay()
    {
        WinScene.SetActive(true);
        Time.timeScale = 0;
    }
    
}
