using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;

    void Awake()
    {
        Instance = this;
    }

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] enemySpawnPositions;
    [SerializeField] private int totalEnemiesCount = 20;
    [SerializeField] private int maxEnemies = 3;
    [SerializeField] private Text enemiesCountText;

    private int enemiesCount;
    private int killedEnemy = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemiesCount = totalEnemiesCount;

        for(int i = 0; i < maxEnemies; i++)
        {
            SpawnEnemyRandomPos();
        }
    }

    void Update()
    {
        if (enemiesCountText)
        {
            enemiesCountText.text = $"のこり {totalEnemiesCount - killedEnemy}人";
        }

        if (GameManager.instance.isGameClear == false)
        {
            if(killedEnemy >= totalEnemiesCount)
            {
                GameManager.instance.GameClear();
            }
        }
    }

    public void OnEnemyDie()
    {
        killedEnemy++;
        if(enemiesCount > 0)
        {
            Debug.Log(enemiesCount);
            SpawnEnemyRandomPos();
        }
    }

    void SpawnEnemyRandomPos()
    {
        Transform spawnPos = enemySpawnPositions[Random.Range(0, enemySpawnPositions.Length)];
        SpawnEnemy(spawnPos.position);
    }

    public void SpawnEnemy(Vector3 pos)
    {
        if (enemiesCount <= 0) return;

        enemiesCount--;
        Instantiate(enemyPrefab, pos, Quaternion.identity);
    }
}
