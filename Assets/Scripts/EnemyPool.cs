using UnityEngine;

public class EnemyPool : ObjectPool<Enemy>
{
    private readonly Enemy _prefab = Resources.Load<Enemy>(Paths.Enemy);

    protected override Enemy GetPrefab() =>
        _prefab;
}
