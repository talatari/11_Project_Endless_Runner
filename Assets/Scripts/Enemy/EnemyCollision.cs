using System;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public event Action<Player> collisionPlayer = delegate { }; 
    public event Action collisionWallDeath = delegate { }; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
            collisionPlayer(player);

        if (other.TryGetComponent(out DeathWall deathWall))
            collisionWallDeath();
    }
}