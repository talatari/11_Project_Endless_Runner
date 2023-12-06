using TMPro;
using UnityEngine;

public class UIScoreTextUpdater : MonoBehaviour
{
    [SerializeField] private TMP_Text _tmpText;

    private EnemyDeathWall _enemyDeathWall;
    private int _score;
    private string _scoreText;
    private bool _isPlayerDead;

    private void Awake()
    {
        _enemyDeathWall = FindObjectOfType<EnemyDeathWall>();
        _scoreText = _tmpText.text;
        UpdateScore();
    }

    private void OnEnable() => 
        _enemyDeathWall.collisionWallDeath += OnIncrementScore;

    private void OnDisable() => 
        _enemyDeathWall.collisionWallDeath -= OnIncrementScore;

    public void SetPlayerDead() => 
        _isPlayerDead = true;

    private void OnIncrementScore()
    {
        if (_isPlayerDead == false)
            _score++;
        
        UpdateScore();
    }

    private void UpdateScore() => 
        _tmpText.text = _scoreText + _score;
}