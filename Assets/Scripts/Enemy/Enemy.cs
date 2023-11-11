using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int _damage;
    [SerializeField]
    private int _maxHealth;
    [SerializeField]
    private float _speed;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector2.down, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerStats player))
        {
            TakeDamage(player);
            Die();
        }
    }

    private void TakeDamage(PlayerStats player)
    {
        player.ApplyDamage(_damage);
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
            Die();
    }

    private void Die()
    {
        _currentHealth = _maxHealth;
        gameObject.SetActive(false);
    }
}
