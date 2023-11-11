using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField]
    private PlayerStats _player;
    [SerializeField]
    private Slider _slider;

    private void Start()
    {
        _slider.maxValue = _player.MaxHealth;
    }

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        _slider.value = health;
    }
}
