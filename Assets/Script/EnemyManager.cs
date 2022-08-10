using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    void Awake()
    {
        Instance = this;
    }

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform enemySpawnPosition;
    [SerializeField] private int enemiesTotalCount = 20;
    [SerializeField] private int maxEnemies = 3;

    private int enemiesRest = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemiesRest = enemiesTotalCount;
    }

    public void OnEnemyDie()
    {
        enemiesRest--;
        if(enemiesRest > 0)
        {
            SpawnEnemy(enemySpawnPosition.position);
        }
        else
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                GameManager.instance.GameClear();
            }
        }
    }

    public void SpawnEnemy(Vector3 pos)
    {
        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }
}
