using UnityEngine;

[RequireComponent(typeof(Food))]
public class FoodCollision : MonoBehaviour
{
    private Food _food;
    
    private void Awake() => 
        _food = GetComponent<Food>();
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.Heal(_food.Health);
            _food.SetInActive();
        }
        
        if (other.TryGetComponent(out EnemyDeathWall enemyDeathWall))
            _food.SetInActive();
    }
}