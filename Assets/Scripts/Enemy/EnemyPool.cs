using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    private List<GameObject> _enemyPool = new ();

    protected void Init(GameObject enemyPrefab)
    {
        for (int i = 0; i < _capacity; i++)
        {   
            GameObject enemySpawned = Instantiate(enemyPrefab, _container.transform);
            enemySpawned.SetActive(false);
            _enemyPool.Add(enemySpawned);
        }
    }

    protected bool TryGetEnemy(out GameObject enemy)
    {
        enemy = _enemyPool.FirstOrDefault(enemyPool => enemyPool.activeSelf == false);
        return enemy is not null;
    }
}