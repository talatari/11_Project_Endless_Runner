using System;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyCollision : MonoBehaviour
{
    private Enemy _enemy;

    public event Action<Player> collisionPlayer = delegate { }; 
    
    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
            collisionPlayer(player);
    }
}