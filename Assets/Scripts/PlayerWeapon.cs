using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerStats), typeof(ParticleSystem))]
public class PlayerWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletTemplate;
    [SerializeField]
    private Transform _shootPoint;

    private ParticleSystem _particleSystem;
    private PlayerStats _player;

    private void Awake()
    {
        _player = GetComponent<PlayerStats>();
        _particleSystem = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        StartCoroutine(DoShot());
    }

    private IEnumerator DoShot()
    {
        while (Time.timeScale == 1)
        {
            yield return new WaitForSeconds(_player.ReloadSpeed);
            Instantiate(_bulletTemplate, _shootPoint.position, Quaternion.identity);
            _particleSystem.Play();
        }
    }
}
