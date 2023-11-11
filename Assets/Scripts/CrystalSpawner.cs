using System.Collections;
using UnityEngine;

public class CrystalSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject _crystalTemplate;
    [SerializeField]
    private float _timeBetweenCrystalSpawn;
    [SerializeField]
    private float _maxWidth;
    [SerializeField]
    private float _minWidth;

    private void Start()
    {
        StartCoroutine(SpawnCrystal());
    }

    private IEnumerator SpawnCrystal()
    {
        while (Time.timeScale == 1) 
        {
            float randomTime = Random.Range(_timeBetweenCrystalSpawn * 0.5f, _timeBetweenCrystalSpawn * 1.5f);
            yield return new WaitForSeconds(randomTime);

            float spawnOffset = Random.Range(_minWidth, _maxWidth);
            Vector2 spawnPoint = new(spawnOffset, transform.position.y);
            Instantiate(_crystalTemplate, spawnPoint, Quaternion.identity);
        }    
    }
}
