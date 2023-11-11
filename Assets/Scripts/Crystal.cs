using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector2.down, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerStats player))
        {
            player.AddCrystal();
            Die();
        }
        else if(collision.TryGetComponent(out DeadZone _))
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);    
    }
}
