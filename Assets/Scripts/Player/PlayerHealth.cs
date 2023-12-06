using System;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 10;
    
    private Player _player;
    private int _currentHealth;
    private int _minHealth = 0;
    private int _clamp;

    public event Action PlayerDestroy;
    public event Action<int, int> HealthChanged;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _player.PlayerTakeDamage += OnTakeDamage;
        _currentHealth = _maxHealth;
    }

    private void Start() => 
        HealthChanged?.Invoke(_currentHealth, _maxHealth);

    private void OnDestroy() => 
        _player.PlayerTakeDamage -= OnTakeDamage;

    private void OnTakeDamage(int damage)
    {
        _clamp = Mathf.Clamp(_currentHealth -= damage, _minHealth, _maxHealth);

        if (_currentHealth <= _minHealth)
            PlayerDestroy?.Invoke();
        
        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }
}