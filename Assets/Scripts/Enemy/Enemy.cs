using UnityEngine;

[RequireComponent(typeof(EnemyCollision))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage = 1;

    private EnemyCollision _enemyCollision;

    private void Awake() => 
        _enemyCollision = GetComponent<EnemyCollision>();

    private void OnEnable()
    {
        _enemyCollision.collisionPlayer += OnTakeDamage;
        _enemyCollision.collisionWallDeath += OnSetInActive;
    }

    private void OnDisable()
    {
        _enemyCollision.collisionPlayer -= OnTakeDamage;
        _enemyCollision.collisionWallDeath -= OnSetInActive;
    }

    private void OnTakeDamage(Player player)
    {
        player.TakeDamage(_damage);
        gameObject.SetActive(false);
    }

    private void OnSetInActive() => 
        gameObject.SetActive(false);
}