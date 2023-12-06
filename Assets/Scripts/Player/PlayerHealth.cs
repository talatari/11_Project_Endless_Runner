using System;
using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 5;
    
    private Player _player;
    private int _currentHealth;
    private int _minHealth = 0;
    private int _clamp;

    public event Action PlayerDestroy;
    public event Action<int, int> HealthChanged;

    public int CurrentHealth => _currentHealth;
    
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

    public void Heal(int health)
    {
        _currentHealth = Mathf.Clamp(_currentHealth += health, _minHealth, _maxHealth);
        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }

    public bool HaveMaxHealth() => 
        _currentHealth == _maxHealth;

    private void OnTakeDamage(int damage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth -= damage, _minHealth, _maxHealth);

        if (_currentHealth <= _minHealth)
            PlayerDestroy?.Invoke();
        
        HealthChanged?.Invoke(_currentHealth, _maxHealth);
    }
}