using UnityEngine;

[RequireComponent(typeof(EnemyCollision))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage = 1;

    private EnemyCollision _enemyCollision;

    private void Start()
    {
        _enemyCollision = GetComponent<EnemyCollision>();
        _enemyCollision.collisionPlayer += OnTakeDamage;
    }

    private void OnDestroy()
    {
        _enemyCollision.collisionPlayer -= OnTakeDamage;
        Destroy(gameObject);
    }

    private void OnTakeDamage(Player player)
    {
        player.TakeDamage(_damage);
        
        Destroy(gameObject);
    }
}