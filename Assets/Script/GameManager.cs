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
    }

    public GameObject gameOverUI;
    public GameObject gameClearUI;

    public AudioClip gameBGM;
    public AudioClip gameOverBGM;

    public bool isGameOver { get; private set; } = false;
    public bool isGameClear { get; private set; } = false;


    void Start()
    {
        gameOverUI.SetActive(false);
        gameClearUI.SetActive(false);
        SoundManager.Instance.PlayBGM(gameBGM);
    }

    void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Retry();
            }
        }
    }

    public void GameClear()
    {
        if (isGameOver) return;

        isGameClear = true;
        Debug.Log("Game Clear");

        //gameClearUI.SetActive(true);
        FadeManager.Instance.LoadScene("Clear", 0.5f);
    }

    public void GameOver()
    {
        if (isGameClear) return;

        isGameOver = true;
        Debug.Log("Game Over");
        gameOverUI.SetActive(true);

        SoundManager.Instance.StopBGM();
        SoundManager.Instance.PlaySE(gameOverBGM);
    }

    public void Retry()
    {
        Debug.Log("Retry");
        gameOverUI.SetActive(false);

        FadeManager.Instance.LoadScene(SceneManager.GetActiveScene().name, 0.5f);
    }
}
