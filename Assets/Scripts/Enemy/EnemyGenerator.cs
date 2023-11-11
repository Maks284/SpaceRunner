using System.Collections;
using UnityEngine;

public class EnemyGenerator : EnemyPool
{
    [SerializeField]
    private float _timeBetweenEnemySpawn;
    [SerializeField]
    private GameObject _enemyTemplate;
    [SerializeField]
    private float _maxWidth;
    [SerializeField]
    private float _minWidth;

    private void Start()
    {
        Initialize(_enemyTemplate);
        StartCoroutine(SetEnemy());
    }

    private IEnumerator SetEnemy()
    {
        while (Time.timeScale == 1)
        {
            float randomTime = Random.Range(_timeBetweenEnemySpawn * 0.5f, _timeBetweenEnemySpawn * 1.5f);
            yield return new WaitForSeconds(randomTime);

            if (TryGetObject(out GameObject enemy))
            {
                float spawnOffset = Random.Range(_minWidth, _maxWidth);
                Vector2 spawnPoint = new(spawnOffset, transform.position.y);
                enemy.SetActive(true);
                enemy.transform.position = spawnPoint;

                DisableObjectAbroadScreen();
            }
        }
    }
}
