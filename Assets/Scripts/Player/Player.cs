using System;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class Player : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private UIScoreTextUpdater _uiScoreTextUpdater;
    
    public event Action<int> PlayerTakeDamage;
    public event Action PlayerDestroy;
    
    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _playerHealth.PlayerDestroy += OnDestroy;
        _uiScoreTextUpdater = FindObjectOfType<UIScoreTextUpdater>();
    }

    private void OnDestroy()
    {
        PlayerDestroy?.Invoke();
        _playerHealth.PlayerDestroy -= OnDestroy;
        gameObject.SetActive(false);
    }

    public void TakeDamage(int damage) => 
        PlayerTakeDamage?.Invoke(damage);

    public void Heal(int health)
    {
        if (_playerHealth.HaveMaxHealth()) 
            _uiScoreTextUpdater.OnIncrementScore();
        else
            _playerHealth.Heal(health);
    }
}