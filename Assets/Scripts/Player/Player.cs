using System;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class Player : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    
    public event Action<int> PlayerTakeDamage;
    public event Action PlayerDestroy;
    
    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _playerHealth.PlayerDestroy += OnDestroy;
    }

    private void OnDestroy()
    {
        PlayerDestroy?.Invoke();
        _playerHealth.PlayerDestroy -= OnDestroy;
        Destroy(gameObject);
    }

    public void TakeDamage(int damage) => 
        PlayerTakeDamage?.Invoke(damage);
}