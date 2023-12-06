using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _tmpText;
    [SerializeField] private Image _fillBar;
    
    private PlayerHealth _playerHealth;

    private void Awake()
    {
        _playerHealth = FindObjectOfType<PlayerHealth>();
        _playerHealth.HealthChanged += OnRefreshHealthBar;
    }

    private void OnDestroy() => 
        _playerHealth.HealthChanged -= OnRefreshHealthBar;

    private void OnRefreshHealthBar(int currentHealth, int maxHealth)
    {
        _tmpText.text = currentHealth + " / " + maxHealth;
        _fillBar.fillAmount = (float) currentHealth / maxHealth;
    }
}