using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth;
    [SerializeField]
    private float _scorePointPerTime;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _reloadSpeed;

    private int _crystals;
    private int _currentHealth;
    private int _score = 0;
    private int _maxScore = 0;

    public int MaxHealth => _maxHealth;
    public float Speed => _speed;
    public float ReloadSpeed => _reloadSpeed;
    public int Crystals => _crystals;
    public int MaxScore => _maxScore;

    public event UnityAction PlayerDied;
    public event UnityAction<int> ScoreChanged;
    public event UnityAction<int> HealthChanged;
    public event UnityAction<int> CrystalCountChanged;

    private void Start()
    {
        LoadData();

        _currentHealth = _maxHealth;

        HealthChanged?.Invoke(_currentHealth);
        ScoreChanged?.Invoke(_score);
        CrystalCountChanged?.Invoke(_crystals);

        StartCoroutine(ScoreCount());
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
            Die();
    }

    public void AddCrystal()
    {
        _crystals++;
        CrystalCountChanged?.Invoke(_crystals);
    }

    private void Die()
    {
        PlayerDied?.Invoke();
        ResetPlayer();
    }

    private IEnumerator ScoreCount()
    {
        while (true)
        {
            yield return new WaitForSeconds(_scorePointPerTime);
            _score++;
            ScoreChanged?.Invoke(_score);
        }
    }

    public void ResetPlayer()
    {
        _currentHealth = _maxHealth;

        if (_score > _maxScore)
            _maxScore = _score;

        _score = 0;

        SaveData();
        HealthChanged?.Invoke(_currentHealth);
        ScoreChanged?.Invoke(_score);
        transform.position = Vector2.zero;
    }

    public void SaveData()
    {
        SaveSystem.SaveData(this);
    }

    public void LoadData()
    {
        PlayerSaveData data = SaveSystem.LoadData();

        if (data != null)
        {
            _crystals = data.Crystal;
            _maxScore = data.Score;
        }
    }
}
