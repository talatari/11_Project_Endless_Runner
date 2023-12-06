using System;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public event Action<Player> collisionPlayer; 
    public event Action collisionWallDeath; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
            collisionPlayer?.Invoke(player);

        if (other.TryGetComponent(out DeathWall deathWall))
            collisionWallDeath?.Invoke();
    }
}