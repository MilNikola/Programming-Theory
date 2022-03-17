using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameOver = false;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject gameStartUI;
    [SerializeField] private TextMeshProUGUI finalBestScoreText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    [SerializeField] private TextMeshProUGUI scoreText;
    private string bestScore;
    private int points = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        DataManager.Instance.LoadScore();
        if (DataManager.Instance.isThereSavedData())
        {
            bestScore = DataManager.Instance.BestScoreUsername + ": " + DataManager.Instance.BestScore;
            bestScoreText.text = bestScore;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Restart();
            }
        }

    }
    public void GameOver() {
        {
            if (DataManager.Instance.isThereSavedData())
            {
                if (points >= DataManager.Instance.BestScore)
                {
                    DataManager.Instance.SaveScore(points);
                }
            }
            else { DataManager.Instance.SaveScore(points); }
            isGameOver = true;
            gameStartUI.SetActive(false);
            gameOverUI.SetActive(true);
            finalScoreText.text = "Score: " + points;
            finalBestScoreText.text = bestScore;
        }
    }
    public void AddPoints(int points)
    {
        this.points += points;
        scoreText.text = "Score: " + this.points;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void StartMenu()
    {
        SceneManager.LoadScene(0);
    }
}
