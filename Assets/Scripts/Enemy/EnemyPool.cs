using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField]
    private GameObject _conteiner;
    [SerializeField]
    private int _capacity;
    [SerializeField]
    private Transform _disablePoin;

    private List<GameObject> _pool = new();

    protected void Initialize(GameObject prefab)
    {
        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, _conteiner.transform);

            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject resault)
    {
        resault = _pool.FirstOrDefault(p => p.activeSelf == false);

        return resault != null;
    }

    protected void DisableObjectAbroadScreen()
    {
        foreach (var item in _pool)
        {
            if (item.activeSelf == true)
            {
                if (item.transform.position.y < _disablePoin.position.y)
                    item.SetActive(false);
            }
        }
    }

    public void ResetEnemyPool()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
        }
    }
}
