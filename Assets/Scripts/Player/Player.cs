using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class Player : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    
    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _playerHealth.PlayerDestroy += OnDestroy;
    }

    private void OnDestroy()
    {
        _playerHealth.PlayerDestroy -= OnDestroy;
        Destroy(gameObject);
    }
}