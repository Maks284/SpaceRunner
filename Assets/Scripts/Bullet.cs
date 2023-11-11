using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private int _damage;
    [SerializeField]
    private float _speed;

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector2.up, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Enemy enemy))
        {
            TakeDamage(enemy);
            Die();
        }
        else if (collision.TryGetComponent(out DeadZone _))
        {
            Die();
        }
    }

    private void TakeDamage(Enemy enemy)
    {
        enemy.ApplyDamage(_damage);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
