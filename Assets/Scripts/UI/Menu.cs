using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup _canvasGroup;
    [SerializeField]
    private EnemyPool _enemyPool;
    [SerializeField]
    private PlayerStats _player;
    [SerializeField]
    private Button _resumeButton;
    [SerializeField]
    private Button _pauseButton;
    [SerializeField]
    private TMP_Text _maxScore;

    private void OnEnable()
    {
        _player.PlayerDied += OnPlayerDied; 
    }

    private void OnDisable()
    {
        _player.PlayerDied -= OnPlayerDied;
    }

    public void OnPauseButtonClick()
    {
        _maxScore.text = "Max Score: " + _player.MaxScore.ToString();
        _canvasGroup.alpha = 1;
        Time.timeScale = 0;
        _pauseButton.gameObject.SetActive(false);   
    }

    public void OnExitButtonClick()
    {
        _player.SaveData();
        Application.Quit(); 
    }

    public void OnRestartButtonClick()
    {
        _enemyPool.ResetEnemyPool();
        _player.ResetPlayer();
        _canvasGroup.alpha = 0;
        _pauseButton.gameObject.SetActive(true);

        if (!_resumeButton.IsActive())
            _resumeButton.gameObject.SetActive(true);

        Time.timeScale = 1;
    }

    public void OnResumeButtonClick()
    {
        Time.timeScale = 1;
        _canvasGroup.alpha = 0;
        _pauseButton.gameObject.SetActive(true);
    }

    private void OnPlayerDied()
    {
        _maxScore.text = "Max Score: " + _player.MaxScore.ToString();
        Time.timeScale = 0;
        _canvasGroup.alpha = 1;
        _enemyPool.ResetEnemyPool();
        _resumeButton.gameObject.SetActive(false);  
    }
}
