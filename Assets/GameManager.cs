using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [Header("Screen Setup Fields")]
    public GameObject gameOverScreen;

    [Header("Game Manager States")]
    public static bool GameIsOver;

    // Start is called before the first frame update
    void Start()
    {
        GameIsOver = false;
        gameOverScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
        {
            Time.timeScale = 0f;
            gameOverScreen.SetActive(true);
        }
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
