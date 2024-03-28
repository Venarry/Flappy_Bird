using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectPool<T> where T : MonoBehaviour
{
    private readonly List<T> _pool = new();

    public T Spawn(Vector2 position, Quaternion rotation)
    {
        T spawnedObject = _pool.FirstOrDefault(c => c.isActiveAndEnabled == false);

        if (spawnedObject == null)
        {
            spawnedObject = Object.Instantiate(GetPrefab(), position, rotation);
            _pool.Add(spawnedObject);

            return spawnedObject;
        }
        else
        {
            spawnedObject.gameObject.SetActive(true);
            spawnedObject.transform.SetPositionAndRotation(position, rotation);
        }

        return spawnedObject;
    }

    public void RemoveAll()
    {
        foreach (T enemy in _pool)
        {
            Object.Destroy(enemy.gameObject);
        }

        _pool.Clear();
    }

    protected abstract T GetPrefab();
}
