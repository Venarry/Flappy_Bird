using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;

    private EnemyPool _enemyPool;
    private BulletPool _bulletPool;
    private int _teamIndex;

    public void Init(EnemyPool enemyPool, BulletPool bulletPool, int teamIndex)
    {
        _enemyPool = enemyPool;
        _bulletPool = bulletPool;
        _teamIndex = teamIndex;
    }

    private void Start()
    {
        StartCoroutine(Generate());
    }

    public void RemovePipes()
    {
        _enemyPool.RemoveAll();
    }

    private IEnumerator Generate()
    {
        WaitForSeconds wait = new(_delay);

        while (enabled) 
        {
            yield return wait;
            Spawn();
        }
    }

    private void Spawn()
    {
        if (_enemyPool == null)
            return;

        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new(transform.position.x, spawnPositionY, transform.position.z);
        Quaternion enemyRotation = Quaternion.Euler(0, -180, 0);

        Enemy enemy = _enemyPool.Spawn(spawnPoint, enemyRotation);
        enemy.Init(_bulletPool, _teamIndex);
    }
}
