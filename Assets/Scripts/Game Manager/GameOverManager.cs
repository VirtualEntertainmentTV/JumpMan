using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;

    private GameObject gameOverPanel;
    private Animator gameOverAnim;

    private Button playAgainBtn, backBtn;

    private GameObject scoreText;

    private Text finalScore;

    private void Awake()
    {
        MakeInstance();
        InitializeVariables();
    }

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

    public void GameOverShowPanel()
    {
        scoreText.SetActive(false);
        gameOverPanel.SetActive(true);

        finalScore.text = "Score\n" + "" + ScoreManager.instance.GetScore();

        gameOverAnim.Play("FadeIn");
    }

    void InitializeVariables()
    {
        gameOverPanel = GameObject.Find("Game Over Panel Holder");
        gameOverAnim = gameOverPanel.GetComponent<Animator>();

        playAgainBtn = GameObject.Find("Play Again Button").GetComponent<Button>();
        backBtn = GameObject.Find("Back Button").GetComponent<Button>();

        playAgainBtn.onClick.AddListener(() => PlayAgain());
        backBtn.onClick.AddListener(() => BackToMenu());

        scoreText = GameObject.Find("Score Text");
        finalScore = GameObject.Find("Final Score").GetComponent<Text>();

        gameOverPanel.SetActive(false);

        
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

   

} // GameOverManager

