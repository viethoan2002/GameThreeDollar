using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    AudioSource audio;
    public GameObject pausescene;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.volume = PlayerPrefs.GetFloat("volume");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausescene.SetActive(true);
            Time.timeScale = 0;
        }
    }
   
    public void Resume()
    {
        pausescene.SetActive(false);
        Time.timeScale = 1;
    }

    public void newgame()
    {
        PlayerPrefs.SetFloat("player_x", -49.42f);
        PlayerPrefs.SetFloat("player_y", 0.61f);
        PlayerPrefs.SetFloat("sl", 3f);
        SceneManager.LoadScene("Park");
    }

    public void back()
    {
        SceneManager.LoadScene("SceneMenu");
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
