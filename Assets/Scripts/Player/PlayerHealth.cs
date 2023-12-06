using System;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 10;
    
    private Player _player;
    private int _currentHealth;
    private int _minHealth = 0;

    public event Action PlayerDestroy = delegate { };
    public event Action<int, int> HealthChanged = delegate { };

    private void Awake()
    {
        _player = GetComponent<Player>();
        _player.PlayerTakeDamage += OnTakeDamage;
        _currentHealth = _maxHealth;
    }

    private void Start() => 
        HealthChanged(_currentHealth, _maxHealth);

    private void OnDestroy() => 
        _player.PlayerTakeDamage -= OnTakeDamage;

    private void OnTakeDamage(int damage)
    {
        Mathf.Clamp(_currentHealth -= damage, _minHealth, _maxHealth);
        
        if (_currentHealth <= _minHealth)
            PlayerDestroy();
        
        HealthChanged(_currentHealth, _maxHealth);
    }
}