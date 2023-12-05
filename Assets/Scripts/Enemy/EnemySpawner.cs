using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnDelay = 1f;

    private float _elapsedTime = 1f;

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime >= _spawnDelay)
        {
            _elapsedTime = 0f;
            Spawn();
        }
    }

    private void Spawn()
    {
        int randomIndex = Random.Range(0, _spawnPoints.Length);
        Instantiate(_enemyPrefab, _spawnPoints[randomIndex].position, Quaternion.identity);
    }
}