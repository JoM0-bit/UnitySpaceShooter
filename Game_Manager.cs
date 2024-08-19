using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool _isGameOver;

    [SerializeField]
    public GameObject _pauseMenu;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _isGameOver == true)
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("esc");
        }

        Pause();

    }

    public void GameOver()
    {
        _isGameOver = true;
    }

    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _pauseMenu.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1.0f;
    }

   public void Resume()
    {
        Time.timeScale = 1.0f;
        _pauseMenu.SetActive(false);
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
}
