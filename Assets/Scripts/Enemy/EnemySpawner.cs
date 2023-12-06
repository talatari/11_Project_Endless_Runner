using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : EnemyPool
{
    [SerializeField] private GameObject[] _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnDelay = 1f;

    private float _elapsedTime = 1f;

    private void Start() => 
        Init(_enemyPrefab);

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _spawnDelay)
        {
            if (TryGetEnemy(out GameObject enemy))
            {
                _elapsedTime = 0f;

                int randomIndex = Random.Range(0, _spawnPoints.Length);
                SetEnemy(enemy, _spawnPoints[randomIndex].position);
            }
        }
    }

    private void SetEnemy(GameObject enemy, Vector3 spawnPosition)
    {
        enemy.SetActive(true);
        enemy.transform.position = spawnPosition;
    }
}