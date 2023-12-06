using UnityEngine;
using UnityEngine.SceneManagement;

public class UIGameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverScreen;

    private Player _player;

    private void Awake() => 
        _player = FindObjectOfType<Player>();

    private void OnEnable() => 
        _player.PlayerDestroy += OnSetActive;

    private void OnDisable() => 
        _player.PlayerDestroy -= OnSetActive;

    public void OnRestartGame()
    {
        int currenSceneIndex = 0;
        
        OnSetInActive();
        SceneManager.LoadScene(currenSceneIndex);
    }

    private void OnSetActive() => 
        _gameOverScreen.SetActive(true);

    private void OnSetInActive() => 
        _gameOverScreen.SetActive(false);
    
}