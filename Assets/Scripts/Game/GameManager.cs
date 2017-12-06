using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public int gold;
    public int waveNumber;
    public int escapedEnemies;
    public int maxAllowedEscapedEnemies = 5;
    public bool enemySpawningOver;
    public AudioClip gameWinSound;
    public AudioClip gameLoseSound;
    private bool gameOver;

    // Use this for initialization
    void Awake()
    {
        Instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if (!gameOver && enemySpawningOver)
        {
            // Check if no enemies left, if so win game   
            if (EnemyManager.Instance.Enemies.Count == 0)
            {
                OnGameWin();
            }
        }
        // When ESC is pressed, quit to the title screen   
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitToTitleScreen();
        }
    }
    private void OnGameWin()
    {
        AudioSource.PlayClipAtPoint(gameWinSound, Camera.main.transform.position);
        gameOver = true;
    }
    public void QuitToTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }
    public void OnEnemyEscape()
    {
        escapedEnemies++;
        if (escapedEnemies == maxAllowedEscapedEnemies)
        {     // Too many enemies escaped, you lose the game   
            OnGameLose();
        }
    }
    private void OnGameLose()
    {
        gameOver = true;
        AudioSource.PlayClipAtPoint(gameLoseSound, Camera.main.transform.position); EnemyManager.Instance.DestroyAllEnemies();
        WaveManager.Instance.StopSpawning();
    }
    public void RetryLevel() {
        SceneManager.LoadScene("Game");
    }
}
