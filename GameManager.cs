using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    private bool _isGameOver;

    public void Update()
    {
        //if space is pressed
        //restart level
        if(Input.GetKeyDown(KeyCode.Space) && _isGameOver == true)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void GameOver()
    {
        _isGameOver = true;
    }
}
