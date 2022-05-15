using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && _isGameOver == true)
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("esc");
        }
    }

    public void GameOver()
    {
        _isGameOver = true;
    }
}
