using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
  public Text enemiesAliveText;
  public Text scoreText;
  public Text highScoreText;
  public GameObject newHighScore;
  public GameObject gameOverModal;
  public AudioSource gameOverMusic;
  public int maxEnemiesAlive = 10;
  private int enemiesAlive = 0;
  private int playerScore = 0;

  private void Start()
  {
    gameOverModal.SetActive(false);
    enemiesAliveText.text = "Health: " + (maxEnemiesAlive - enemiesAlive);
    scoreText.text = "Score: " + playerScore;
    highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore");
  }

  public void DecreaseEnemiesAlive()
  {
    enemiesAlive--;
    playerScore++;

    enemiesAliveText.text = "Health: " + (maxEnemiesAlive - enemiesAlive);
    scoreText.text = "Score: " + playerScore;
  }

  public void IncreaseEnemiesAlive()
  {
    enemiesAlive++;
    enemiesAliveText.text = "Health: " + (maxEnemiesAlive - enemiesAlive);

    if (enemiesAlive >= maxEnemiesAlive)
    {
      EndGame();
    }
  }

  void EndGame()
  {
    gameOverMusic.PlayOneShot(gameOverMusic.clip, gameOverMusic.volume);

    Time.timeScale = 0;
    gameOverModal.SetActive(true);

    if (PlayerPrefs.GetInt("HighScore") == 0 || playerScore > PlayerPrefs.GetInt("HighScore"))
    {
      PlayerPrefs.SetInt("HighScore", playerScore);
      newHighScore.SetActive(true);
    }
  }

  public void Retry()
  {
    Time.timeScale = 1;
    SceneManager.LoadScene("Game");
  }
}
