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

    void Start()
    {
        gameOverUI.SetActive(false);
    }

    void Update()
    {
        
    }

    public void GameClear()
    {
        Debug.Log("Game Clear");
    }

    public void GameOver()
    {
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
