using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;

    private float Score = 0.0f;

    [SerializeField]
    private Sprite[] LivesSprites;

    [SerializeField]
    private Image LivesImage;

    [SerializeField]
    private GameObject GameOverText;

    [SerializeField]
    private GameObject RestartText;



    // Start is called before the first frame update
    void Start()
    {
       // LivesSprites[
        _scoreText.text = "Score: " + Score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(float _Score)
    {
        _scoreText.text = "Score: " + _Score;
    }

    public void updateLives(int _lives)
    {
        LivesImage.sprite = LivesSprites[_lives];
    }

    public void updateGameover()
    {
        GameOverText.SetActive(true);
        RestartText.SetActive(true);
        StartCoroutine(GameOverFlickerRoutine());
    }

    IEnumerator GameOverFlickerRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            GameOverText.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            GameOverText.SetActive(true);

        }
    }
}
