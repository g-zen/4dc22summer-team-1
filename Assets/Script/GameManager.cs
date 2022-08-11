using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public GameObject gameOverUI;
    public bool isGameOver { get; private set; } = false;
    public bool isGameClear { get; private set; } = false;


    void Start()
    {
        gameOverUI.SetActive(false);
    }

    void Update()
    {
        
    }

    public void GameClear()
    {
        if (isGameOver) return;

        isGameClear = true;
        Debug.Log("Game Clear");
    }

    public void GameOver()
    {
        if (isGameClear) return;

        isGameOver = true;
        Debug.Log("Game Over");
        gameOverUI.SetActive(true);
    }

    public void Retry()
    {
        Debug.Log("Retry");
        gameOverUI.SetActive(false);

        FadeManager.Instance.LoadScene(SceneManager.GetActiveScene().name, 0.5f);
    }
}
