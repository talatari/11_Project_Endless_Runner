using System;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public event Action<Player> collisionPlayer = delegate { }; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
            collisionPlayer(player);

        if (other.TryGetComponent(out WallDeath wallDeath))
            Destroy(gameObject);
    }
}