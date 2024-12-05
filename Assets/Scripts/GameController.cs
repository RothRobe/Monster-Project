using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject gameOverScreen;
    private bool _gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RestartGame();
            }
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        _gameOver = true;
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        gameOverScreen.SetActive(false);
        _gameOver = false;
        Time.timeScale = 1; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void QuitGame()
    {
        Application.Quit(); // Quit the application (works only in builds, not in the editor)
        Debug.Log("Game Quit!"); // Useful for testing in the editor
    }
}
